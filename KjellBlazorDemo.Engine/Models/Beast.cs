using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.Engine.Models
{
    
    public class Beast : Asset
    {      
        private int CycleCounter { get; set; }

        public Beast(string name, int x, int y, int h = 16, int w = 17)
        {
            Name = name;
            Left = x;
            Top = y;
            offsetY = 0;
            offsetX = 0;
            Width = w;
            Height = h;
        }

        public void MovementAnimation()
        {
            CycleCounter++;

            if (CycleCounter % 10 == 0)
            {
                if (offsetX < 134)
                {
                    //the last frame in the png is cut off, should probably
                    //fix the png instead of hardcoding this here
                    if (offsetX == 119) { offsetX += 16; }
                    else { offsetX += 17; }
                }
                else
                {
                    offsetX = 0;
                }
            }

            if (CycleCounter >= 100)
            {
                MessageText = "";
                CycleCounter = 0;
            }
        }
        
    }
}
