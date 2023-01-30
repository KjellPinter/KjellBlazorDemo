using KjellBlazorDemo.Engine.GameLogic;
using KjellBlazorDemo.Engine.Interfaces;

namespace KjellBlazorDemo.Engine
{
    public class Controls : IControls
    {
        private readonly IPlayerManager _playerManager;
        private readonly ISpells _spells;
        private Dictionary<string, Action> _keyDownCommands = null!;
        private Dictionary<string, Action> _keyUpCommands = null!;
        private readonly List<string> _keysDown;

        public Controls(IPlayerManager player, ISpells spells)
        {
            _playerManager = player;
            _spells = spells;
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
                //spells
                { "Digit1", () => _spells.TeleportRandom() },
                { "Digit2", () => _spells.Haste() },
                { "Digit3", () => _spells.Fireball() },
                { "Digit4", () => _spells.SummonBeast() },
                { "Space", () => _spells.TeleportRandom() }
            };

            _keyUpCommands = new Dictionary<string, Action>()
            {
                { "KeyA", () => _playerManager.StopHorizontalMovement() },
                { "KeyD", () => _playerManager.StopHorizontalMovement() },
                { "KeyS", () => { } },
                { "KeyW", () => { } },
                { "ArrowLeft", () => _playerManager.StopHorizontalMovement() },
                { "ArrowRight", () => _playerManager.StopHorizontalMovement() },
                { "ArrowUp", () => _playerManager.StopVerticalMovement() },
                { "ArrowDown", () => _playerManager.StopVerticalMovement() },
                { "Space", () => { } }
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

            if (_keyUpCommands.ContainsKey(key))
                _keyUpCommands[key].Invoke();
        }
    }
}
