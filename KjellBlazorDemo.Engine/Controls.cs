using KjellBlazorDemo.Engine.Interfaces;

namespace KjellBlazorDemo.Engine
{
    public class Controls : IControls
    {

        private IPlayerManager _playerManager;
        private readonly Settings _settings;

        public Controls(IPlayerManager player, Settings settings)
        {
            _playerManager = player;
            _settings = settings;
        }

        public void KeyDown(string key)
        {
            switch (key)
            {
                case "ArrowLeft":
                    MoveLeft(_settings.MOVEMENT_DISTANCE);
                    break;
                case "ArrowRight":
                    _playerManager.MoveHorizontal(_settings.MOVEMENT_DISTANCE);
                    break;
                case "ArrowUp":
                    _playerManager.MoveVertical(-_settings.MOVEMENT_DISTANCE);
                    break;
                case "ArrowDown":
                    _playerManager.MoveVertical(_settings.MOVEMENT_DISTANCE);
                    break;
                default:
                    //throw new ArgumentException("no definition for this key");
                    break;
            }
        }

        private void MoveLeft(int distance)
        {
            if (_playerManager.PositionLeft - distance < _settings.MIN_X)
                distance = 0;
                       
            _playerManager.MoveHorizontal(-distance);
                        
        }
    }
}
