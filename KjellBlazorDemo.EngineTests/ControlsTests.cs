using KjellBlazorDemo.Engine;
using KjellBlazorDemo.Engine.Interfaces;
using Moq;

namespace KjellBlazorDemo.EngineTests
{
    public class ControlsTests
    {
        private readonly Mock<IPlayerManager> _player;
        private readonly Mock<Settings> _settings;
        private readonly IControls _controls;
        public ControlsTests()
        {
            //global setup 
            _player = new Mock<IPlayerManager>();
            _settings = new Mock<Settings>();
            _controls = new Controls(_player.Object, new Spells(_player.Object, _settings.Object));
        }

        //[Fact]
        //public void SpaceDoesSpecialMove()
        //{
        //    //arrange

        //    //act
        //    _controls.KeyDown("Space");

        //    //assert
        //    _player.Verify(p => p.SpecialMove(), Times.Once());
        //}

        [Theory]
        [InlineData("ArrowLeft")]
        [InlineData("ArrowRight")]
        [InlineData("ArrowUp")]
        [InlineData("ArrowDown")]
        public void ArrowsMovePlayer(string key)
        {
            //arrange 
            int amount = _settings.Object.MOVEMENT_DISTANCE;

            if (key == "ArrowLeft" || key == "ArrowUp")
            {
                amount = -amount;
            }

            //act
            _controls.KeyDown(key);
            _controls.KeyUp(key);

            //assert - may fire multiple times if key is held down
            if (key == "ArrowRight")
            {
                _player.Verify(x => x.MoveRight(), Times.AtLeast(1));
            }

            if (key == "ArrowLeft")
            {
                _player.Verify(x => x.MoveLeft(), Times.AtLeast(1));
            }

            if (key == "ArrowUp")
            {
                _player.Verify(x => x.MoveUp(), Times.AtLeast(1));
            }

            if (key == "ArrowDown")
            {
                _player.Verify(x => x.MoveDown(), Times.AtLeast(1));
            }
        }

        [Fact]
        public void DontAllowMoveOffscreenLeftTop()
        {
            //setup a real player object
            var Settings = new Settings();
            var Player = new PlayerManager(Settings);
            var Controls = new Controls(Player, new Spells(Player, Settings));

            //act
            for (int i = 0; i < 50; i++)
            {
                Controls.KeyDown("ArrowLeft");
            }

            Controls.KeyUp("ArrowLeft");

            for (int i = 0; i < 50; i++)
            {
                Controls.KeyDown("ArrowUp");
            }

            Controls.KeyUp("ArrowUp");

            //assert
            Assert.True(Player.Position.X >= Settings.MIN_X);
            Assert.True(Player.Position.Y >= Settings.MIN_Y);
        }

        [Fact]
        public async void DontAllowMoveOffscreenRightBottom()
        {
            //setup a real player object
            var Settings = new Settings();

            //set artificallly small play field so test can run quicker
            //has to be at least 100,200 though because that is the starting position
            Settings.MAX_X = 124;
            Settings.MAX_Y = 224;
            
            var Player = new PlayerManager(Settings);
            var Controls = new Controls(Player, new Spells(Player, Settings));

            //act
            //hold down right for 1 second
            Controls.KeyDown("ArrowRight");
            await Task.Delay(1000);
            Controls.KeyUp("ArrowRight");

            //hold down button for 1 second
            Controls.KeyDown("ArrowDown");
            await Task.Delay(1000);
            Controls.KeyUp("ArrowDown");
            
            

            //assert
            Assert.True(Player.Position.X <= Settings.MAX_X);
            Assert.True(Player.Position.Y <= Settings.MAX_Y);
        }
    }
}