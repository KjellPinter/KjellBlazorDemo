namespace KjellBlazorDemo.Engine.Models
{
    public class Trash : Asset
    {

        public Trash(int top, int left)
        {
            Top = top;
            Left = left;

            offsetY = -72;

            Name = "trash";

            var rnd = new Random();
            var roll = rnd.Next(3);

            switch (roll)
            {
                case 0:
                    offsetX = -7;
                    break;
                case 1:
                    offsetX = -39;
                    break;
                default:
                    offsetX = -71;
                    break;
            }
        }

    }
}
