namespace KjellBlazorDemo.App.Models
{
    public class Trash : Asset
    {

        internal Trash(int top, int left)
        {
            Top = top;
            Left = left;

            offsetY = -64;

            Name = "trash";

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
