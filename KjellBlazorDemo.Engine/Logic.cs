using KjellBlazorDemo.Engine.Interfaces;
using KjellBlazorDemo.Engine.Models;

namespace KjellBlazorDemo.Engine
{
    public class Logic : ILogic
    {
        public List<Asset> DetectCollisions(List<Asset> assets, IPlayerManager player, Type T)
        {

            //todo: these should definitely not be hardcoded, should take height width into account of both items
            //also https://codereview.stackexchange.com/questions/149782/2d-collision-detection
            return assets.Where(o => o.Left > (player.Position.X - 20)
                           && o.Left < (player.Position.X) + 20
                           && o.Top > (player.Position.Y - 32)
                           && o.Top < (player.Position.Y) + 32
                           && o.GetType() == T)
                .ToList();
        }
    }
}