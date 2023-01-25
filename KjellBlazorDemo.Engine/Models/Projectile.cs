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

            //DETECT COLLISION HERE INSTEAD OF INTERACTIONS???  OR EVEN IN ASSET?
            
            MoveTowardsPoint(Target.Left, Target.Top);

            if (this.Left == Target.Left && this.Top == Target.Top)
            {
                Assets.Remove(this);
                Target.Stop();
                Target.MessageText = "I'm hit!";
            }
        }

    }
}
