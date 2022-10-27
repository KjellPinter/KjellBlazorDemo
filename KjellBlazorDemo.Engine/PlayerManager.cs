using KjellBlazorDemo.Engine.Interfaces;
using KjellBlazorDemo.Engine.Models;

namespace KjellBlazorDemo.Engine
{
    public class PlayerManager : IPlayerManager
    {
        public int PositionTop { get; set; }
        public int PositionLeft { get; set; }
        public Character Character { get; set; }
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

        public void MoveRight() => Move(_settings.MOVEMENT_DISTANCE, 0);

        public void MoveLeft() => Move(-_settings.MOVEMENT_DISTANCE, 0);
        
        public void MoveUp() => Move(0, -_settings.MOVEMENT_DISTANCE);        

        public void MoveDown() => Move(0, _settings.MOVEMENT_DISTANCE);
        
        //x y are amounts to move on that axis
        private void Move(int x, int y)
        {
            if ((PositionLeft += x) < _settings.MIN_X)
                x = 0;
            

            if ((PositionTop += y) < _settings.MIN_Y)
                y = 0;
            
            SetFacingDirectionAndAnimate(x, y);
            PositionLeft += x;
            PositionTop += y;                
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
