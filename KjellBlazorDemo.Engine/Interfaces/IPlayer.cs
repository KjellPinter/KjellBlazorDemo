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
        public void Move(string Direction);

    }      
}
