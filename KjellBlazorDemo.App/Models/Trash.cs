namespace KjellBlazorDemo.App.Models
{
    public class Trash
    {

        public int Top { get; set; }
        public int Left { get; set; }

        internal Trash(int top, int left)
        {
            Top = top;
            Left = left;
        }

    }
}
