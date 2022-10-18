namespace KjellBlazorDemo.Engine.Models
{
    public class Mob : Asset
    {


        public bool IsAttacking { get; set; }

        private int CycleCounter { get; set; }

        public Mob(string name, int x, int y, int h, int w)
        {
            Name = name;
            offsetX = x;
            offsetY = y;
            Width = h;
            Height = w;
            CycleCounter = 0;
        }

        public void AttackPlayer()
        {
            if (IsAttacking == false)
            {
                CycleCounter = 0;
                IsAttacking = true;
                MessageText = "HEY!";
                Visible = true;
            }
        }

        public void Animate()
        {
            CycleCounter++;

            if (CycleCounter % 10 == 0)
            {
                //CycleCounter = 0;
                offsetX = offsetX == -8 ? -86 : -8;
            }

            if (CycleCounter >= 50)
            {
                MessageText = "";
                CycleCounter = 0;
            }
        }
    }
}
