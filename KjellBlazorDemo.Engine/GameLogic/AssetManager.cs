
namespace KjellBlazorDemo.Engine.GameLogic
{
    public class AssetManager
    {

        public void ResetAssets(List<Asset> list)
        {
            list.Clear();
            PopulateWalls(list, 3);
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
        public void PopulateWalls(List<Asset> list, int count)
        {
            var rnd = new Random();
            var x = rnd.Next(500);
            var y = rnd.Next(500);
            
            for (int i = 0; i < count; i++)
            {                         
                var m = new Wall(x+(i*25), y, 25, 25);
                m.Visible = true;
                list.Add(m);
            }

            x = rnd.Next(500);
            y = rnd.Next(500);
            
            for (int i = 0; i < count; i++)
            {
                var m = new Wall(x, y + (i * 25), 25, 25);
                m.Visible = true;
                list.Add(m);
            }
        }
    }
}
