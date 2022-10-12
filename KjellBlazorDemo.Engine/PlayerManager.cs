using KjellBlazorDemo.Engine.Interfaces;
using KjellBlazorDemo.Engine.Models;

namespace KjellBlazorDemo.Engine
{
    public class PlayerManager : IPlayerManager
    {
        public int PositionTop { get; set; }
        public int PositionLeft { get; set; }
        public Character Character { get; set; }
     
        public PlayerManager()
        {
            PositionTop = 100;
            PositionLeft = 200;

            this.Character = new Character();
        }

        public override string ToString()
        {
            return String.Concat(this.Character.Name, " (",
                this.PositionLeft.ToString(), ",",
                this.PositionTop.ToString(), ")");
        }

        public void MoveHorizontal(int amount, int minX, int maxX)
        {
            if (PositionLeft + amount < minX)
                amount = 0;

            PositionLeft += amount;

            if (amount > 0)
            {
                Character.FaceRight();
            }
            else
            {
                Character.FaceLeft();
            }
        }

        public void MoveVertical(int amount, int minY, int maxY)
        {
            if (PositionTop + amount < minY)
                amount = 0;

            PositionTop += amount;

            if (amount > 0)
            {
                Character.FaceForward();
            }
            else
            {
                Character.FaceBack();
            }
        }
    }
}
