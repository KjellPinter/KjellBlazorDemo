using KjellBlazorDemo.Engine;
using KjellBlazorDemo.Engine.Interfaces;
using Moq;

namespace KjellBlazorDemo.EngineTests
{
    public class ControlsTests
    {

        private Mock<IPlayerManager> _player;
        private Mock<Settings> _settings;
        private IControls _controls;

        public ControlsTests()
        {
            //global setup 
            _player = new Mock<IPlayerManager>();
            _settings = new Mock<Settings>();
            _controls = new Controls(_player.Object, _settings.Object);
        }

        [Fact]
        public void SpaceDoesSpecialMove()
        {
            //arrange

            //act
            _controls.KeyDown("Space");

            //assert
            _player.Verify(p => p.SpecialMove(), Times.Once());
        }

        [Theory]
        [InlineData("ArrowLeft", 1, 0)]
        [InlineData("ArrowRight", 1, 0)]
        [InlineData("ArrowUp", 0, 1)]
        [InlineData("ArrowDown", 0, 1)]
        public void ArrowsMovePlayer(string key, int horizontal, int vertical)
        {
            //arrange 
            int amount = _settings.Object.MOVEMENT_DISTANCE;

            if (key == "ArrowLeft" || key == "ArrowUp")
            {
                amount = -amount;
            }

            //act
            _controls.KeyDown(key);

            //assert
            _player.Verify(x => x.MoveHorizontal(amount, _settings.Object.MIN_X, _settings.Object.MAX_X), Times.Exactly(horizontal));
            _player.Verify(x => x.MoveVertical(amount, _settings.Object.MIN_Y, _settings.Object.MAX_Y), Times.Exactly(vertical));
        }

        [Fact]
        public void DontAllowMoveOffscreenLeftTop()
        {
            //setup a real player object
            var Player = new PlayerManager();
            var Settings = new Settings();
            var Controls = new Controls(Player, Settings);

            //act
            for (int i = 0; i < 50; i++)
            {
                Controls.KeyDown("ArrowLeft");
            }

            for (int i = 0; i < 50; i++)
            {
                Controls.KeyDown("ArrowUp");
            }

            //assert
            Assert.True(Player.PositionLeft >= Settings.MIN_X);
            Assert.True(Player.PositionTop >= Settings.MIN_Y);
        }


    }
}