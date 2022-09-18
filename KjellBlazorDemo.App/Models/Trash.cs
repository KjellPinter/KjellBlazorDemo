namespace KjellBlazorDemo.App.Models
{
    public class Trash
    {

        public int Top { get; set; }
        public int Left { get; set; }
        public int offsetY { get; set; }
        public int offsetX { get; set; }

        internal Trash(int top, int left)
        {
            Top = top;
            Left = left;

            offsetY = -64;

            var rnd = new Random();
            var roll = rnd.Next(3);

            switch (roll)
            {
                case 0:
                    offsetX = 0;
                    break;
                case 1:
                    offsetX = -32;
                    break;
                default:
                    offsetX = -64;
                    break;
            }
        }

    }
}
