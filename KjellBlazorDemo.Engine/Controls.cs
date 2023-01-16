using KjellBlazorDemo.Engine.Interfaces;

namespace KjellBlazorDemo.Engine
{
    public class Controls : IControls
    {
        private readonly IPlayerManager _playerManager;
        private Dictionary<string, Action> _keyDownCommands = null!;
        private Dictionary<string, Action> _keyUpCommands = null!;
        private readonly List<string> _keysDown;

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
                { "KeyA", () => _playerManager.MoveLeft() },
                { "KeyS", () => _playerManager.MoveDown() },
                { "KeyD", () => _playerManager.MoveRight() },
                { "KeyW", () => _playerManager.MoveUp() },
                { "ArrowLeft", () => _playerManager.MoveLeft() },
                { "ArrowRight", () => _playerManager.MoveRight() },
                { "ArrowUp", () => _playerManager.MoveUp() },
                { "ArrowDown", () => _playerManager.MoveDown() },
                { "Space", () => _playerManager.SpecialMove() }
            };

            _keyUpCommands = new Dictionary<string, Action>()
            {
                { "KeyA", () => _playerManager.StopHorizontalMovement() },
                { "KeyD", () => _playerManager.StopHorizontalMovement() },
                { "KeyS", () => { } },
                { "KeyW", () => { } },
                { "ArrowLeft", () => _playerManager.StopHorizontalMovement() },
                { "ArrowRight", () => _playerManager.StopHorizontalMovement() },
                { "ArrowUp", () => { } },
                { "ArrowDown", () => { } },
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
                    RepeatKeyPressWhileDown(key);
                }
            }
        }

        private async void RepeatKeyPressWhileDown(string key)
        {
            while (_keysDown.Contains(key))
            {
                await Task.Delay(100);

                //check again in case it was removed during above delay
                if (_keysDown.Contains(key))
                {
                    _keyDownCommands[key].Invoke();
                }
            }
        }

        public async void KeyUp(string key)
        {            
            _keysDown.Remove(key);
            _keyUpCommands[key].Invoke();
        }
    }
}
