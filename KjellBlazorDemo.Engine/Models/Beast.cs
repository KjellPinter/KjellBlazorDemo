using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.Engine.Models
{
    
    public class Beast : Asset
    {      
        private int CycleCounter { get; set; }
        public Asset Target;

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

        public void SetTarget(Asset target)
        {
            if (Target == null)
                Target = target;
        }

        public void ChaseTarget()
        {
            if (Target != null)
            {
                var pnt = new Point(Target.Left, Target.Top);
                MoveTowardsPoint(pnt);
                MovementAnimation();

                //check if we hit the target
                if (this.Left == Target.Left && this.Top == Target.Top)
                {
                    Target.Stop();
                    Target.MessageText = "Hi Kitty";
                    this.Target = null;
                }
            }            
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
