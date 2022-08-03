using KjellBlazorDemo.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.Engine.Interfaces
{
    public interface IPlayer
    {
        public int PositionTop { get; set;  }
        public int PositionLeft { get; set;  }
        public void MoveHorizontal(int amount);

        public void MoveVertical(int amount);
        public Character Character { get; set; }

    }      
}
