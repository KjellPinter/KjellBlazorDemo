using KjellBlazorDemo.Engine.Interfaces;

namespace KjellBlazorDemo.Engine
{
    public class Player : IPlayer
    {
        public int PositionTop { get; set; }
        public int PositionLeft { get; set; }

        public Player()
        {
            PositionTop = 100;
            PositionLeft = 200;
        }

        public void MoveHorizontal(int amount)
        {
            PositionLeft += amount;
        }

        public void MoveVertical(int amount)
        {
            PositionTop += amount;
        }
    }
}
