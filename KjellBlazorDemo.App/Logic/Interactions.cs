using KjellBlazorDemo.App.Models;
using KjellBlazorDemo.Engine;
using KjellBlazorDemo.Engine.Interfaces;

namespace KjellBlazorDemo.App.Logic
{
    public class Interactions
    {

        internal void CollisionDetect(List<Asset> AssetList, IPlayerManager Player)
        {
            var cols = AssetList.Where(o => o.Left > (Player.PositionLeft - 34) && o.Left < (Player.PositionLeft) + 2
                            && o.Top > (Player.PositionTop - 34) && o.Top < (Player.PositionTop) + 2).ToList();

            Mob? troll = (Mob?)AssetList.Where(o => o.Name == "troll").FirstOrDefault();

            if (troll is not null)
            {
                troll.IsAttacking = true;
                MoveMobTowardsPlayer(troll, Player);

                foreach (var c in cols)
                {
                    AssetList.Remove(c);
                }
            }
        }

        internal void MoveMobTowardsPlayer(Mob mob, IPlayerManager Player)
        {
            if (mob.IsAttacking)
            {
                if (mob.Top < Player.PositionTop)
                {
                    ++mob.Top;
                }

                if (mob.Top > Player.PositionTop)
                {
                    --mob.Top;
                }

                if (mob.Left < Player.PositionLeft)
                {
                    ++mob.Left;
                }

                if (mob.Left > Player.PositionLeft)
                {
                    --mob.Left;
                }
            }
        }


    }
}
