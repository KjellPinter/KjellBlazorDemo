using System;
using System.Collections.Generic;
using System.Linq;
using KjellBlazorDemo.App.Logic;
using KjellBlazorDemo.App.Models;


namespace KjellBlazorDemo.AppTests.Logic
{
    /// <summary>
    /// TODO: make the counts dynamic based on settings
    /// </summary>
    public class AssettManagerTests
    {
        AssetManager assetManager = new AssetManager();

        [Fact]
        public void ResetAssetsResets()
        {
            //arrange
            var list = new List<Asset>();

            //act
            assetManager.ResetAssets(list);

            //assert
            var mobs = list.Where(o => o.GetType() == typeof(Mob)).Cast<Mob>().ToList();
            var trashes = list.Where(o => o.GetType() == typeof(Trash)).Cast<Trash>().ToList();
            Assert.Single(mobs!);
            Assert.Equal(5, trashes!.Count);
        }

        [Fact]
        public void TrashPopulates()
        {
            //arrange
            var list = new List<Asset>();

            //act            
            assetManager.PopulateTrash(list, 5);

            //assert
            Assert.Equal(5, list.Count);
        }

        [Fact]
        public void MobPopulates()
        {
            //arrange
            var list = new List<Asset>();

            //act
            assetManager.PopulateMobs(list, 5);

            //assert
            Assert.Equal(5, list.Count);
        }
    }
}
