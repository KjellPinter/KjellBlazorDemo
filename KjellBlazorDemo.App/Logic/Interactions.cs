using KjellBlazorDemo.Engine.Models;
using KjellBlazorDemo.Engine;
using KjellBlazorDemo.Engine.Interfaces;

namespace KjellBlazorDemo.App.Logic
{
    public class Interactions
    {

        private IPlayerManager _player = null!;
        private List<Asset> _assetList = null!;

        internal void CollisionDetect(List<Asset> AssetList, IPlayerManager Player)
        {
            _player = Player;
            _assetList = AssetList;

            //remove trash, and if any trash has been removed then active the troll attack
            if (RemoveTrashWhichTouchesPlayer())
            {
                _assetList.Where(o => o.GetType() == typeof(Mob)).Cast<Mob>().ToList().ForEach(o => o.AttackPlayer());
            }

            MobAction();

        }

        internal bool RemoveTrashWhichTouchesPlayer()
        {
            bool result = false;

            //todo: these should definitely not be hardcoded, should take height width into account of both items
            //also https://codereview.stackexchange.com/questions/149782/2d-collision-detection
            var cols = _assetList.Where(o => o.Left > (_player.PositionLeft - 20) //player pos - trash width
                            && o.Left < (_player.PositionLeft) + 20 //player pos + trash width
                            && o.Top > (_player.PositionTop - 32) //player pos - trash height 
                            && o.Top < (_player.PositionTop) + 32
                            && o.GetType() == typeof(Trash)) //player pos + trash height
                .ToList();

            foreach (var c in cols)
            {
                result = true;
                _assetList.Remove(c);
            }

            return result;
        }

        internal void MobAction()
        {


            MoveMobTowardsPlayer();

            //todo - combine with trash logic and make dynamic
            var cols = _assetList.Where(o => o.Left > (_player.PositionLeft - 20)
                           && o.Left < (_player.PositionLeft) + 20
                           && o.Top > (_player.PositionTop - 32)
                           && o.Top < (_player.PositionTop) + 32
                           && o.GetType() == typeof(Mob))
                .ToList();

            foreach (Mob m in cols)
            {
                m.IsAttacking = false; //todo - actually do something 
                m.MessageText = "";
            }
        }

        internal void MoveMobTowardsPlayer()
        {
            Mob? mob = (Mob?)_assetList.Where(o => o.GetType() == typeof(Mob)).FirstOrDefault();
            
            if (mob is not null && mob.IsAttacking)
            {

                mob.Animate();

                if (mob.Top < _player.PositionTop)
                {
                    ++mob.Top;
                }

                if (mob.Top > _player.PositionTop)
                {
                    --mob.Top;
                }

                if (mob.Left < _player.PositionLeft)
                {
                    ++mob.Left;
                }

                if (mob.Left > _player.PositionLeft)
                {
                    --mob.Left;
                }
            }
        }


    }
}
