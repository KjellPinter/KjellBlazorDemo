using KjellBlazorDemo.Engine.Interfaces;
using KjellBlazorDemo.Engine.Models;

namespace KjellBlazorDemo.Engine
{
    public class PlayerManager : IPlayerManager
    {
        public int PositionTop { get; set; }
        public int PositionLeft { get; set; }
        public Character Character { get; set; }
        public bool IsMoving { get; set; }
        private Settings _settings;
     
        public PlayerManager(Settings settings)
        {

            _settings = settings;

            PositionTop = 100;
            PositionLeft = 200;

            this.Character = new Character();
        }

        public override string ToString()
        {
            return String.Concat(this.Character.Name, " (",
                this.PositionLeft.ToString(), ",",
                this.PositionTop.ToString(), ")");
        }

    
        public void SpecialMove()
        {
            //temporary action
            PositionTop = 100;
            PositionLeft = 200;
        }

        public void StopMovement()
        {
            IsMoving = false;
        }

        public void MoveRight()
        {
            MoveHorizontal(_settings.MOVEMENT_DISTANCE);
        }

        public void MoveLeft()
        {
            MoveHorizontal(-_settings.MOVEMENT_DISTANCE);
        }

        public void MoveUp()
        {
            MoveVertical(-_settings.MOVEMENT_DISTANCE);
        }

        public void MoveDown()
        {
            MoveVertical(_settings.MOVEMENT_DISTANCE);
        }

        public void MoveHorizontal(int amount)
        {
            if (PositionLeft + amount < _settings.MIN_X)
                amount = 0;

                PositionLeft += amount;

                if (amount > 0)
                {
                    Character.FaceRight();
                }
                else
                {
                    Character.FaceLeft();
                }

        }

        public void MoveVertical(int amount)
        {
            if (PositionTop + amount < _settings.MIN_Y)
                amount = 0;

                PositionTop += amount;

                if (amount > 0)
                {
                    Character.FaceForward();
                }
                else
                {
                    Character.FaceBack();
                }

        }

    }
}
