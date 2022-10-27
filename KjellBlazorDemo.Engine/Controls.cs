using KjellBlazorDemo.Engine.Interfaces;

namespace KjellBlazorDemo.Engine
{
    public class Controls : IControls
    {

        private IPlayerManager _playerManager;
        private Dictionary<string, Action> _keyDownCommands;
        private Dictionary<string, Action> _keyUpCommands;
        private List<string> _keysDown;

        public Controls(IPlayerManager player)
        {
            _playerManager = player;
            _keysDown = new List<string>();
            DefineCommands();
        }

        private void DefineCommands()
        {
            _keyDownCommands = new Dictionary<string, Action>()
            {
                { "ArrowLeft", () => _playerManager.MoveLeft() },
                { "ArrowRight", () => _playerManager.MoveRight() },
                { "ArrowUp", () => _playerManager.MoveUp() },
                { "ArrowDown", () => _playerManager.MoveDown() },
                { "Space", () => _playerManager.SpecialMove() }
            };

            _keyUpCommands = new Dictionary<string, Action>()
            {
                { "ArrowLeft", () => _playerManager.MoveLeft() },
                { "ArrowRight", () => _playerManager.MoveRight() },
                { "ArrowUp", () => _playerManager.MoveUp() },
                { "ArrowDown", () => _playerManager.MoveDown() },
            };
        }

        public async void KeyDown(string key)
        {
            if (_keyDownCommands.ContainsKey(key) && !_keysDown.Contains(key))
            {
                _keyDownCommands[key].Invoke();

                //if there is a keyup then we keep firing this command until keyup fires
                if (_keyUpCommands.ContainsKey(key))
                {
                    _keysDown.Add(key);

                    while (_keysDown.Contains(key))
                    {
                        await Task.Delay(100);
                        _keyDownCommands[key].Invoke();
                    }
                }
            }

        }

        public void KeyUp(string key)
        {
            _keysDown.Remove(key);
        }

    }

}
