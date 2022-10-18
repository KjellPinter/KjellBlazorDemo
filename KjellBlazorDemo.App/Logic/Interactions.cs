using KjellBlazorDemo.Engine.Models;
using KjellBlazorDemo.Engine;
using KjellBlazorDemo.Engine.Interfaces;

namespace KjellBlazorDemo.App.Logic
{
    public class Interactions
    {

        private IPlayerManager Player = null!;
        private List<Asset> AssetList = null!;
        private ILogic Logic = null!;

        internal void CollisionDetect(List<Asset> assetList, IPlayerManager player, ILogic logic)
        {
            Player = player;
            AssetList = assetList;
            Logic = logic;

            //remove trash, and if any trash has been removed then active the troll attack
            if (RemoveTrashWhichTouchesPlayer())
            {
                assetList.Where(o => o.GetType() == typeof(Mob)).Cast<Mob>().ToList().ForEach(o => o.AttackPlayer());
            }

            MobAction();

        }

        internal bool RemoveTrashWhichTouchesPlayer()
        {
            bool result = false;

            var cols = Logic.DetectCollisions(AssetList, Player, typeof(Trash));

            foreach (var c in cols)
            {
                result = true;
                AssetList.Remove(c);
            }

            return result;
        }

        internal void MobAction()
        {

            MoveMobTowardsPlayer();

            var cols = Logic.DetectCollisions(AssetList, Player, typeof(Trash)).ToList();

            foreach (Mob m in cols)
            {
                m.IsAttacking = false; //todo - actually do something 
                m.MessageText = "";
            }
        }

        internal void MoveMobTowardsPlayer()
        {
            Mob? mob = (Mob?)AssetList.Where(o => o.GetType() == typeof(Mob)).FirstOrDefault();
            
            if (mob is not null && mob.IsAttacking)
            {

                mob.Animate();

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
