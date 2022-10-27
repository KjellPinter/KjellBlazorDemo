using KjellBlazorDemo.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.Engine
{

    public class Settings
    {
 
        public Settings()
        {
            MOVEMENT_DISTANCE = 5;
            CHARACTER = 1;
            MIN_X = 0;
            MAX_X = 400;
            MIN_Y = 0;
            MAX_Y = 400;
            GAME_TICK = 20;
        }

        //todo: implement
        public int GAME_TICK { get; set; }

        public int MOVEMENT_DISTANCE { get; set; }

        public int CHARACTER  { get; set; }

        public int MIN_X  { get; set; }

        public int MAX_X { get; set; }

        public int MIN_Y { get; set; }

        public int MAX_Y { get; set; }
    }
}
