
using KjellBlazorDemo.Engine.Models;
using System.Drawing;

namespace KjellBlazorDemo.Engine.GameLogic
{
    public class AssetManager
    {
        private Settings _settings;
        
        public AssetManager(Settings settings) {
            _settings = settings;
        }
        

        public void ResetAssets(List<Asset> list, int MobCount = 1)
        {
            list.Clear();
            PopulateWalls(list, 2, 4);
            PopulateTrash(list, 5);
            PopulateMobs(list, MobCount);
        }
        
        public void PopulateTrash(List<Asset> assets, int count)
        {
            var rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                int t = rnd.Next(_settings.MIN_Y, _settings.MAX_Y);
                int l = rnd.Next(_settings.MIN_X, _settings.MAX_X);
                var trash = new Trash(t, l);


                if (!DetectAsestWallCollision(assets, trash))
                    assets.Add(trash);
            }
        }

        private bool DetectAsestWallCollision(List<Asset> assets, Asset asset)
        {
            foreach (var wall in assets.Where(o => o.GetType() == typeof(Wall)))
            {
                var isWallCollision = wall.Rectangle().IntersectsWith(asset.Rectangle());
                if (isWallCollision)
                {
                    return true;
                }
            }
            
            return false;
        }

        public bool DetectAnyAssetWallClipping(List<Asset> assets)
        {
            if (assets is not null)
            {
                foreach (var wall in assets.Where(o => o.GetType() == typeof(Wall)))
                {
                    foreach (var asset in assets.Where(o => o.GetType() != typeof(Wall)))
                    {
                        var isWallCollision = wall.Rectangle().IntersectsWith(asset.Rectangle());
                        if (isWallCollision)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;

        }

        public void PopulateMobs(List<Asset> list, int count)
        {
            
            for (int i = 0; i < count; i++)
            {
                var m = new Mob("troll", -8, -3 , 25, 25);
                m.Top = 100;
                m.Left = 100 * i;
                m.Visible = false;
                list.Add(m);
            }
        }
        public void PopulateWalls(List<Asset> list, int wallCount, int wallLength)
        {
            var rnd = new Random();

            //horizontal walls
            for (int i = 0; i < wallCount; i++)
            {
                int x = rnd.Next(_settings.MAX_X);
                int y = rnd.Next(_settings.MAX_Y);

                for (int j = 0; j < wallLength; j++)
                {
                    var m = new Wall(x, y + (j * 25), 25, 25);
                    m.Visible = true;                    
                    list.Add(m);
                }
            }

            //vertical walls
            for (int i = 0; i < wallCount; i++)
            {
                int x = rnd.Next(500);
                int y = rnd.Next(500);

                for (int j = 0; j < wallLength; j++)
                {
                    var m = new Wall(x + (j * 25), y, 25, 25);
                    m.Visible = true;
                    list.Add(m);
                }
            }


        }
    }
}
