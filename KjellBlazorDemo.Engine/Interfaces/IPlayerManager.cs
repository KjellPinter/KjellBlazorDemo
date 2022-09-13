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
        public void MoveHorizontal(int amount, int minX, int maxX);

        public void MoveVertical(int amount, int minY, int maxY);
        public Character Character { get; set; }

    }      
}
