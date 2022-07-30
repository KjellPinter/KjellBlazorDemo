using KjellBlazorDemo.Engine.Interfaces;

namespace KjellBlazorDemo.Engine
{
    public class Controls : IControls
    {

        private readonly IPlayer _player;

        public Controls(IPlayer player)
        {
            _player = player;
        }



        public void KeyDown(string key)
        {
            switch (key)
            {
                case "ArrowLeft":
                    _player.MoveHorizontal(-Settings.MOVEMENT_DISTANCE);
                    break;
                case "ArrowRight":
                    _player.MoveHorizontal(Settings.MOVEMENT_DISTANCE);
                    break;
                case "ArrowUp":
                    _player.MoveVertical(-Settings.MOVEMENT_DISTANCE);
                    break;
                case "ArrowDown":
                    _player.MoveVertical(Settings.MOVEMENT_DISTANCE);
                    break;
                default:
                    //throw new ArgumentException("no definition for this key");
                    break;
            }
        }
    }
}
