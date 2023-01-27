using KjellBlazorDemo.Engine.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.Engine.Interfaces
{
    public interface IPlayerManager
    {
        public Point Position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public void MoveRight();
        public void MoveLeft();
        public void MoveUp();
        public void MoveDown();
        //public bool IsMovingHorizontally { get; set; }
        public bool IsMovingVertically { get; set; }
        public List<Asset> Assets { get; set; }
        public Character Character { get; set; }

        public Rectangle Rectangle();
        void StopHorizontalMovement();
        void StopVerticalMovement();

        //spells
        void TeleportRandom();
        void Haste();
        void Fireball();
        void SummonBeast();
    }      
}
