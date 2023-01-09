
namespace KjellBlazorDemo.Engine.GameLogic
{
    public class AssetManager
    {

        public void ResetAssets(List<Asset> list)
        {
            list.Clear();
            PopulateWalls(list, 2, 4);
            PopulateTrash(list, 5);
            PopulateMobs(list, 1);
        }

        public void PopulateTrash(List<Asset> list, int count)
        {
            var rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                int t = rnd.Next(500);
                int l = rnd.Next(500);
                list.Add(new Trash(t, l));
            }
        }

        public void PopulateMobs(List<Asset> list, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var m = new Mob("troll", -8, -3, 25, 25);
                m.Visible = false;
                list.Add(m);
            }
        }
        public void PopulateWalls(List<Asset> list, int wallCount, int wallLength)
        {
            var rnd = new Random();
            
            for (int i = 0; i < wallCount; i++)
            {
                int x = rnd.Next(500);
                int y = rnd.Next(500);

                for (int j = 0; j < wallLength; j++)
                {
                    var m = new Wall(x, y + (j * 25), 25, 25);
                    m.Visible = true;
                    list.Add(m);
                }
            }

            
        }
    }
}
