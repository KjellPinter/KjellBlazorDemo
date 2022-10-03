namespace KjellBlazorDemo.App.Models
{
    abstract public class Asset
    {
        public string? Name { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
        public int offsetY { get; set; }
        public int offsetX { get; set; }
    }
}
