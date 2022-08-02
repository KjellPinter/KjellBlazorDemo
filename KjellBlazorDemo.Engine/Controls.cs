using KjellBlazorDemo.Engine.Interfaces;

namespace KjellBlazorDemo.Engine
{
    public class Controls : IControls
    {

        private readonly IPlayer _player;
        private readonly Settings _settings;

        public Controls(IPlayer player, Settings settings)
        {
            _player = player;
            _settings = settings;
        }

        

        public void KeyDown(string key)
        {
            switch (key)
            {
                case "ArrowLeft":
                    _player.MoveHorizontal(-_settings.MOVEMENT_DISTANCE);
                    break;
                case "ArrowRight":
                    _player.MoveHorizontal(_settings.MOVEMENT_DISTANCE);
                    break;
                case "ArrowUp":
                    _player.MoveVertical(-_settings.MOVEMENT_DISTANCE);
                    break;
                case "ArrowDown":
                    _player.MoveVertical(_settings.MOVEMENT_DISTANCE);
                    break;
                default:
                    //throw new ArgumentException("no definition for this key");
                    break;
            }
        }

    }
}
