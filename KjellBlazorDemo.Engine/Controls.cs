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
                    _playerManager.MoveHorizontal(-_settings.MOVEMENT_DISTANCE, _settings.MIN_X, _settings.MAX_X);
                    break;
                case "ArrowRight":
                    _playerManager.MoveHorizontal(_settings.MOVEMENT_DISTANCE, _settings.MIN_X, _settings.MAX_X);
                    break;
                case "ArrowUp":
                    _playerManager.MoveVertical(-_settings.MOVEMENT_DISTANCE, _settings.MIN_Y, _settings.MAX_Y);
                    break;
                case "ArrowDown":
                    _playerManager.MoveVertical(_settings.MOVEMENT_DISTANCE, _settings.MIN_Y, _settings.MAX_Y);
                    break;
                default:
                    //throw new ArgumentException("no definition for this key");
                    break;
            }
        }

    }
}
