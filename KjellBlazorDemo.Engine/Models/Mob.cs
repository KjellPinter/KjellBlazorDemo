namespace KjellBlazorDemo.Engine.Models
{
    public class Mob : Asset
    {


        public bool IsAttacking { get; set; }

        private int CycleCounter { get; set; }

        public Mob(string name)
        {
            Name = name;
            offsetX = -8;
            offsetY = -2;
            CycleCounter = 0;
        }

        public void Animate()
        {
            CycleCounter++;

            if (CycleCounter ==10)
            {
                CycleCounter = 0;
                offsetX = offsetX == -8 ? -86 : -8;
            }

            
        }
    }
}
