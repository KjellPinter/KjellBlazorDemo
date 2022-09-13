using KjellBlazorDemo.Engine;
using KjellBlazorDemo.Engine.Interfaces;
using Moq;

namespace KjellBlazorDemo.EngineTests
{
    public class ControlsTests
    {        

        public ControlsTests()
        {         
        }

        [Theory]
        [InlineData("ArrowLeft", 1, 0)]
        [InlineData("ArrowRight", 1, 0)]
        [InlineData("ArrowUp", 0, 1)]
        [InlineData("ArrowDown", 0, 1)]
        public void ArrowsMovePlayer(string key, int horizontal, int vertical)
        {
            //assert 
            var _player = new Mock<IPlayerManager>();
            var _settings = new Mock<Settings>();

            var _controls = new Controls(_player.Object, _settings.Object);

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
            Assert.True(Player.PositionLeft > Settings.MIN_X);
            Assert.True(Player.PositionTop > Settings.MIN_Y);
        }


    }
}