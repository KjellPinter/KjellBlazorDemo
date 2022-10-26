using KjellBlazorDemo.Engine.Interfaces;

namespace KjellBlazorDemo.Engine
{
    public class Controls : IControls
    {

        private IPlayerManager _playerManager;
        private readonly Settings _settings;
        private Dictionary<string, Action> _commands;

        public Controls(IPlayerManager player, Settings settings)
        {
            _playerManager = player;
            _settings = settings;
            DefineCommands();
        }

        private void DefineCommands()
        {
            _commands = new Dictionary<string, Action>()
            {
                { "ArrowLeft", () => _playerManager.MoveHorizontal(-_settings.MOVEMENT_DISTANCE, _settings.MIN_X, _settings.MAX_X) },
                { "ArrowRight", () => _playerManager.MoveHorizontal(_settings.MOVEMENT_DISTANCE, _settings.MIN_X, _settings.MAX_X) },
                { "ArrowUp", () => _playerManager.MoveVertical(-_settings.MOVEMENT_DISTANCE, _settings.MIN_Y, _settings.MAX_Y) },
                { "ArrowDown", () => _playerManager.MoveVertical(_settings.MOVEMENT_DISTANCE, _settings.MIN_Y, _settings.MAX_Y) },
                { "Space", () => _playerManager.SpecialMove() }
            };

        }

        public void KeyDown(string key)
        {
            if (_commands.ContainsKey(key))
            {
                _commands[key].Invoke();
            }
        }

    }
}
