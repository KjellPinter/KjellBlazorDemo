using KjellBlazorDemo.Engine;
using KjellBlazorDemo.Engine.Interfaces;
using Moq;

namespace KjellBlazorDemo.EngineTests
{
    public class ControlsTests
    {
        private Controls? _controls;

        [Theory]
        [InlineData("ArrowLeft", 1, 0)]
        [InlineData("ArrowRight", 1, 0)]
        [InlineData("ArrowUp", 0, 1)]
        [InlineData("ArrowDown", 0, 1)]
        public void ArrowsMovePlayer(string key, int horizontal, int vertical)
        {
            //assert 
            var _player = new Mock<IPlayer>();
            var _settings = new Mock<Settings>();

            _controls = new Controls(_player.Object, _settings.Object);

            int amount = _settings.Object.MOVEMENT_DISTANCE;

            //act
            _controls.KeyDown(key);

            //assert
            _player.Verify(x => x.MoveHorizontal(amount), Times.Exactly(horizontal));
            _player.Verify(x => x.MoveVertical(amount), Times.Exactly(vertical));
        }

    }
}