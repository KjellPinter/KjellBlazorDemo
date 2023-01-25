namespace KjellBlazorDemo.Engine.Models
{
    public class Mob : Asset
    {


        public bool IsChasing { get; set; }

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

        public void ChasePlayer(IPlayerManager player)
        {
            if (IsChasing == false)
            {
                CycleCounter = 0;
                IsChasing = true;
                MessageText = "HEY!";
                Visible = true;
            }
            else
            {
                this.MovementAnimation();
                this.MoveTowardsPoint(player.PositionLeft, player.PositionTop);
            }
        }
        
        public void AnimateAttack()
        {
            CycleCounter++;

            if (CycleCounter % 10 == 0)
            {
                if (offsetX == -8)
                {
                    offsetX = -130;
                    offsetY = -97;
                }
                else
                {
                    offsetX = -8;
                    offsetY = -3;
                }
            }

            if (CycleCounter >= 100)
            {
                MessageText = "";
                CycleCounter = 0;
            }
        }

        public void MovementAnimation()
        {
            CycleCounter++;

            if (CycleCounter % 10 == 0)
            {
                offsetX = offsetX == -8 ? -86 : -8;
            }

            if (CycleCounter >= 100)
            {
                MessageText = "";
                CycleCounter = 0;
            }
        }
    }
}
