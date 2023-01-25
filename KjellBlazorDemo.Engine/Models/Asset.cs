using System.Drawing;
using System.Numerics;

namespace KjellBlazorDemo.Engine.Models
{
    abstract public class Asset
    {
        public string? Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
        public int offsetY { get; set; }
        public int offsetX { get; set; }
        
        public string? Sprite { get; set; }
        /// <summary>
        /// Populates floating div under the asset, for example a label or dialog. 
        /// </summary>
        public string? MessageText { get; set; }
        public bool Visible { get; set; } = true;
        public bool CollideWithPlayer { get; set; } = true;
        
        public Rectangle Rectangle()
        {
            return new Rectangle(this.Left, this.Top, this.Width, this.Height);
        }

        public void MoveTowardsPoint(int x, int y)
        {
            if (this.Top < y)
            {
                ++this.Top;
            }

            if (this.Top > y)
            {
                --this.Top;
            }
            
            if (this.Left < x)
            {
                ++this.Left;
            }

            if (this.Left > x)
            {
                --this.Left;
            }
        }

        public virtual void Stop()
        {
            //by default do nothing
        }

    }
}
