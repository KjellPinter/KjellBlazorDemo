
namespace KjellBlazorDemo.Engine.Models
{
    public class Wall : Asset
    {
        public Wall(int top, int left, int height, int width)
        {
            Top = top;
            Left = left;
            Height = height;
            Width = width;
            CollideWithPlayer = true;
            Name = "wall";
        }
    }
}
