
namespace KjellBlazorDemo.App.Logic
{
    public class Interactions
    {

        private IPlayerManager Player = null!;
        private List<Asset> AssetList = null!;
        private ILogic Logic = null!;

        public void CollisionDetect(List<Asset> assetList, IPlayerManager player, ILogic logic)
        {
            Player = player;
            AssetList = assetList;
            Logic = logic;

            //remove trash, and if any trash has been removed then activate the troll attack
            if (RemoveTrashWhichTouchesPlayer())
            {
                assetList.Where(o => o.GetType() == typeof(Mob)).Cast<Mob>().ToList().ForEach(o => o.ChasePlayer());
            }

            MobActions();
        }

        public bool RemoveTrashWhichTouchesPlayer()
        {
            bool result = false;

            foreach (var c in Logic.DetectCollisions(AssetList, Player, typeof(Trash)))
            {
                result = true;
                AssetList.Remove(c);
            }

            return result;
        }

        public void MobActions()
        {
            MobsChasing();
            MobsAttacking();
        }

        public void MobsChasing()
        {
            List<Mob> mobs = AssetList.Where(o => o.GetType() == typeof(Mob))
                .OfType<Mob>().Where(m => m.IsChasing).ToList();

            mobs.ForEach(m => MoveMobTowardsPlayer(m));
        }

        private void MoveMobTowardsPlayer(Mob mob)
        {
            mob.AnimateRun();

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

        private void MobsAttacking()
        {
            var cols = Logic.DetectCollisions(AssetList, Player, typeof(Mob)).ToList();

            foreach (Mob m in cols)
            {
                m.AnimateAttack();
                m.IsChasing = false;
                m.MessageText = "";
            }
        }
    }
}
