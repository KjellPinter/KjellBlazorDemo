using KjellBlazorDemo.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.Engine.Interfaces
{
    public interface ILogic
    {
        public List<Asset> DetectCollisions(List<Asset> assets, IPlayerManager player, Type T);
    }
}
