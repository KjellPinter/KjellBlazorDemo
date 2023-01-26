using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.Engine.Models
{
    public class Projectile : Asset
    {
        private Asset Target;
        private List<Asset> Assets;

        public Projectile(string Name, Asset Target, List<Asset> Assets, int x, int y, int width = 8, int height = 8)
        {
            this.Name = Name;
            this.Assets = Assets;
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
            var pnt = new Point(Target.Left, Target.Top);
            MoveTowardsPoint(pnt);

            //check if we hit the target
            if (this.Left == Target.Left && this.Top == Target.Top)
            {
                Assets.Remove(this);
                Target.Stop();
                Target.MessageText = "I'm hit!";
            }
        }

    }
}
