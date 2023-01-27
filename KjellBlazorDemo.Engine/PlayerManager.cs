﻿using KjellBlazorDemo.App.Logic;
using KjellBlazorDemo.Engine.Interfaces;
using KjellBlazorDemo.Engine.Models;
using System.Drawing;

namespace KjellBlazorDemo.Engine
{
    public class PlayerManager : IPlayerManager
    {
        //public int Position.Y { get; set; }
        //public int Position.X { get; set; }

        public Point Position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        
        public Character Character { get; set; }
        private readonly Settings _settings;
        public HorizontalMovement HorizontalMovementDirection { get; set; }
        public bool IsMovingVertically { get; set; }

        public List<Asset>? Assets { get; set; }

        public enum HorizontalMovement
        {
            Left,
            Right,
            None
        }

        public PlayerManager(Settings settings)
        {
            _settings = settings;
            Position = new Point(100, 200);
            Width = 20;
            Height = 29;
            HorizontalMovementDirection = HorizontalMovement.None;
            this.Character = new Character();
        }

        public override string ToString()
        {
            return String.Concat(this.Character.Name, " (",
                this.Position.X.ToString(), ",",
                this.Position.Y.ToString(), ")");
        }

        #region Spells

        public void TeleportRandom()
        {
            var rnd = new Random();
            Position = new Point(rnd.Next(0, _settings.MAX_X), rnd.Next(0, _settings.MAX_Y));         
        }

        public void Haste()
        {
            _settings.MOVEMENT_DISTANCE = 10;
        }

        public void Fireball()
        {
            //look for target
            var target = Assets?.FirstOrDefault(o => o.GetType() == typeof(Mob));
            var balls = Assets?.Where(o => o.Name == "fireball");
            

            //create fireball asset as long as it has a target and there are less than 4 already
            if (target != null && balls?.Count() < 3)
            {
                var fireball = new Projectile("fireball", target, Assets, this.Position.X, this.Position.Y);
                Assets.Add(fireball);
            }
            
        }

        public void SummonBeast()
        {
            var cats = Assets?.Where(o => o.Name == "cat");

            if (cats?.Count() == 0)
            {
                var cat = new Beast("cat", this.Position.X, this.Position.Y);
                Assets.Add(cat);
            }
        }

        #endregion

        #region Player Movement

        public void MoveRight() => Move(_settings.MOVEMENT_DISTANCE, 0);

        public void MoveLeft() => Move(-_settings.MOVEMENT_DISTANCE, 0);

        public void MoveUp() => Move(0, -_settings.MOVEMENT_DISTANCE);

        public void MoveDown() => Move(0, _settings.MOVEMENT_DISTANCE);

        //x y are amounts to move on that axis
        private void Move(int x, int y)
        {
            x = ValidateHorizontalMovement(x);
            y = ValidateVerticalMovement(y);

            if (x != 0)
            {
                HorizontalMovementDirection = x > 0 ? HorizontalMovement.Right : HorizontalMovement.Left;
            }

            if (y != 0) { IsMovingVertically = true; }

            //if we are moving on both axis then do then at the same time in order to smooth it out
            if (HorizontalMovementDirection != HorizontalMovement.None && IsMovingVertically)
            {
                //if this is a call for horizontal movment, cancel it.  Otherwise we end up doubling movement speed
                if (x != 0)
                {
                    x = 0;
                }
                else
                {
                    //add horizontal movement to vertical movement so it becomes one motion.  
                    x = HorizontalMovementDirection == HorizontalMovement.Left ? -_settings.MOVEMENT_DISTANCE : _settings.MOVEMENT_DISTANCE;
                }
            }
            
            SetFacingDirectionAndAnimate(x, y);

            this.Position = new Point(this.Position.X + x, this.Position.Y + y);

            if (DetectClipping())
            {
                this.Position = new Point(this.Position.X - x, this.Position.Y - y);
            }
        }

        public void StopHorizontalMovement()
        {
            HorizontalMovementDirection = HorizontalMovement.None;
        }

        public void StopVerticalMovement()
        {
            this.IsMovingVertically = false;
        }

        public bool DetectClipping()
        {
            if (Assets is not null)
            {
                foreach (var wall in Assets.Where(o => o.GetType() == typeof(Wall)))
                {
                    var isPlayerWallCollision = wall.Rectangle().IntersectsWith(Rectangle());
                    if (isPlayerWallCollision)
                    {
                        return true;
                    }
                }
            }
            
            return false;

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
                if (Position.X + x < _settings.MIN_X)
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
                if ((Position.Y + y) < _settings.MIN_Y)
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

            if (HorizontalMovementDirection == HorizontalMovement.None && y != 0)
            {
                if (y > 0)
                {
                    Character.FaceForward();
                }
                else
                {
                    Character.FaceBack();
                }
            }
        }
        public Rectangle Rectangle()
        {
            return new Rectangle(this.Position.X, this.Position.Y, Width, Height);
        }        

        #endregion
    }
}
