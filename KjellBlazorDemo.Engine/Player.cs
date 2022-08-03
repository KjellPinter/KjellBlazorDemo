using KjellBlazorDemo.Engine.Interfaces;
using KjellBlazorDemo.Engine.Models;

namespace KjellBlazorDemo.Engine
{
    public class Player : IPlayer
    {
        public int PositionTop { get; set; }
        public int PositionLeft { get; set; }
        public Character Character { get; set; }
     
        public Player()
        {
            PositionTop = 100;
            PositionLeft = 200;

            this.Character = new Character();
        }

        public override string ToString()
        {
            return Character.Name;
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
