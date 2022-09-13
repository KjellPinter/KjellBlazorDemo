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
            _player.Verify(x => x.MoveHorizontal(amount), Times.Exactly(horizontal));
            _player.Verify(x => x.MoveVertical(amount), Times.Exactly(vertical));
        }

        [Fact]
        public void DontAllowMoveOffscreen()
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

            //assert
            Assert.True(Player.PositionLeft > Settings.MIN_X);
        }


    }
}