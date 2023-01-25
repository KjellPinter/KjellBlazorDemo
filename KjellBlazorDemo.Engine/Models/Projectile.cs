using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.Engine.Models
{
    public class Projectile : Asset
    {
        private Asset Target;

        public Projectile(string Name, Asset Target, int x, int y, int width = 8, int height = 8)
        {
            this.Name = Name;
            this.Left = x;
            this.Top = y;
            this.Width = width;
            this.Height = height;
            this.Target = Target;

            this.offsetX = 0;
            this.offsetY = 0;
            
        }

        public void ChaseTarget()
        {
            MoveTowardsPoint(Target.Left, Target.Top);
        }

    }
}
