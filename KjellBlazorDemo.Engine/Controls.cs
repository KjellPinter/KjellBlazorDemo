using KjellBlazorDemo.Engine.Interfaces;

namespace KjellBlazorDemo.Engine
{
    public class Controls : IControls
    {

        private IPlayerManager _playerManager;
        private readonly Settings _settings;
        private Dictionary<string, Action> _commands;

        public Controls(IPlayerManager player)
        {
            _playerManager = player;
            DefineCommands();
        }

        private void DefineCommands()
        {
            _commands = new Dictionary<string, Action>()
            {
                { "ArrowLeft", () => _playerManager.MoveLeft() },
                { "ArrowRight", () => _playerManager.MoveRight() },
                { "ArrowUp", () => _playerManager.MoveUp() },
                { "ArrowDown", () => _playerManager.MoveDown() },
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

        public void KeyUp(string key)
        {
            _playerManager.StopMovement();
        }

    }
}
