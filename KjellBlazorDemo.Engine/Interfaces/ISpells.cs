using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.Engine.Interfaces
{
    public interface ISpells
    {
        public void TeleportRandom();

        public void Haste();

        public void Fireball();

        public void SummonBeast();
    }
}
