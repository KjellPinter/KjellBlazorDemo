using KjellBlazorDemo.Engine.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.Engine.GameLogic
{
    public  class Spells : ISpells
    {
        private readonly IPlayerManager _player;
        private readonly Settings _settings;

        public Spells(IPlayerManager playerManager, Settings settings)
        {
            _player = playerManager;
            _settings = settings;            
        }

        public void TeleportRandom()
        {
            var rnd = new Random();
            _player.Position = new Point(rnd.Next(0, _settings.MAX_X), rnd.Next(0, _settings.MAX_Y));

            //check for collision
            if (_player.DetectClipping())
            {
                TeleportRandom();
            }
        }

        public void Haste()
        {
            _settings.MOVEMENT_DISTANCE = 10;
        }
        
        public void Fireball()
        {
            //look for target
            var target = _player.Assets.FirstOrDefault(o => o.GetType() == typeof(Mob));
            var balls = _player.Assets.Where(o => o.Name == "fireball");


            //create fireball asset as long as it has a target and there are less than 4 already
            if (target != null && balls?.Count() < 3)
            {
                var fireball = new Projectile("fireball", target, _player.Assets, _player.Position.X, _player.Position.Y);
                _player.Assets.Add(fireball);
            }
        }

        public void SummonBeast()
        {
            var cats = _player.Assets.Where(o => o.Name == "cat");

            if (cats?.Count() == 0)
            {
                var cat = new Beast("cat", _player.Position.X, _player.Position.Y);
                _player.Assets.Add(cat);
            }
        }
    }
}
