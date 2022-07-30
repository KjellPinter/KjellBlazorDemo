using KjellBlazorDemo.Engine;
using KjellBlazorDemo.Engine.Interfaces;
using Moq;

namespace KjellBlazorDemo.EngineTests
{
    public class ControlsTests
    {
        private Controls? _controls;

        [Theory]
        [InlineData("ArrowLeft", -Settings.MOVEMENT_DISTANCE, 1, 0)]
        [InlineData("ArrowRight", Settings.MOVEMENT_DISTANCE, 1, 0)]
        [InlineData("ArrowUp", -Settings.MOVEMENT_DISTANCE, 0, 1)]
        [InlineData("ArrowDown", Settings.MOVEMENT_DISTANCE, 0, 1)]
        public void ArrowsMovePlayer(string key, int amount, int horizontal, int vertical)
        {
            //assert 
            var _player = new Mock<IPlayer>();
            _controls = new Controls(_player.Object);


            //act
            _controls.KeyDown(key);

            //assert
            _player.Verify(x => x.MoveHorizontal(amount), Times.Exactly(horizontal));
            _player.Verify(x => x.MoveVertical(amount), Times.Exactly(vertical));
        }

    }
}