using KjellBlazorDemo.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.Engine.Interfaces
{
    public interface IPlayerManager
    {
        public int PositionTop { get; set;  }
        public int PositionLeft { get; set;  }
        public void MoveRight();
        public void MoveLeft();
        public void MoveUp();
        public void MoveDown();
        public bool IsMovingHorizontally { get; set; }
        public void SpecialMove();
        public Character Character { get; set; }

    }      
}
