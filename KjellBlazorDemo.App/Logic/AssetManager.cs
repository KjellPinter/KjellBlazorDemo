﻿using KjellBlazorDemo.Engine.Models;

namespace KjellBlazorDemo.App.Logic
{
    internal class AssetManager
    {

        internal void ResetAssets(List<Asset> list)
        {
            list.Clear();
            PopulateTrash(list, 5);
            PopulateMobs(list, 1);
        }

        internal void PopulateTrash(List<Asset> list, int count)
        {
            var rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                int t = rnd.Next(500);
                int l = rnd.Next(500);
                list.Add(new Trash(t, l));
            }
        }

        internal void PopulateMobs(List<Asset> list, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var m = new Mob("troll", -8, -3, 25, 25);
                m.Visible = false;
                list.Add(m);
            }
            
        }
    }
}
