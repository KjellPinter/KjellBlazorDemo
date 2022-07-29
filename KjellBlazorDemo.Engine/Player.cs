using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KjellBlazorDemo.Engine.Interfaces;

namespace KjellBlazorDemo.Engine
{
    public class Player : IPlayer
    {
        public int PositionTop { get; set; }
        public int PositionLeft { get; set; }

        public void Move(string Direction)
        {
            
        }
    }
}
