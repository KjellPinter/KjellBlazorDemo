namespace KjellBlazorDemo.App.Models
{
    public class Mob : Asset
    {

        public bool IsAttacking { get; set; }

        public Mob(string name)
        {
            Name = name;
        }
    }
}
