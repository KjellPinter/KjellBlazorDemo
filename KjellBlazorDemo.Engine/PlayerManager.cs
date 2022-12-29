using KjellBlazorDemo.Engine.Interfaces;
using KjellBlazorDemo.Engine.Models;

namespace KjellBlazorDemo.Engine
{
    public class PlayerManager : IPlayerManager
    {
        public int PositionTop { get; set; }
        public int PositionLeft { get; set; }
        public Character Character { get; set; }
        private readonly Settings _settings;
        public bool IsMovingHorizontally { get; set; }

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

        public void MoveRight() => Move(_settings.MOVEMENT_DISTANCE, 0);

        public void MoveLeft() => Move(-_settings.MOVEMENT_DISTANCE, 0);

        public void MoveUp() => Move(0, -_settings.MOVEMENT_DISTANCE);

        public void MoveDown() => Move(0, _settings.MOVEMENT_DISTANCE);

        //x y are amounts to move on that axis
        private void Move(int x, int y)
        {
            x = ValidateHorizontalMovement(x);
            y = ValidateVerticalMovement(y);
            
            IsMovingHorizontally = (x != 0);
            
            SetFacingDirectionAndAnimate(x, y);
            PositionLeft += x;
            PositionTop += y;
        }

        /// <summary>
        /// Returns 0 when potential movement is invalid
        /// </summary>
        /// <param name="x"></param>
        /// <returns>x value</returns>
        private int ValidateHorizontalMovement(int x)
        {
            if (x < 0)
            {
                if (PositionLeft + x < _settings.MIN_X)
                    x = 0;
            }

            return x;
        }

        /// <summary>
        /// Returns 0 when potential movement is invalid
        /// </summary>
        /// <param name="y"></param>
        /// <returns>y value</returns>
        private int ValidateVerticalMovement(int y)
        {
            if (y < 0)
            {
                if ((PositionTop + y) < _settings.MIN_Y)
                    y = 0;
            }

            return y;
        }

        private void SetFacingDirectionAndAnimate(int x, int y)
        {
            //dont do anything for 0
            if (x > 0)
            {
                Character.FaceRight();
            }

            if (x < 0)
            {
                Character.FaceLeft();
            }

            if (!IsMovingHorizontally)
            {
                if (y > 0)
                {
                    Character.FaceForward();
                }

                if (y < 0)
                {
                    Character.FaceBack();
                }
            }
        }
    }
}
