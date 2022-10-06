using System;
using System.Collections.Generic;
using System.Linq;
using KjellBlazorDemo.App.Logic;
using KjellBlazorDemo.App.Models;


namespace KjellBlazorDemo.AppTests.Logic
{
    public class AssettManagerTests
    {
        [Fact]
        public void TrashPopulates()
        {
            //arrange
            var assetManager = new AssetManager();

            //act
            var list = new List<Asset>();
            assetManager.PopulateTrash(list, 5);

            //assert
            Assert.Equal(5, list.Count);
        }

        [Fact]
        public void MobPopulates()
        {
            //arrange
            var assetManager = new AssetManager();

            //act
            var list = new List<Asset>();
            assetManager.PopulateMobs(list, 5);

            //assert
            Assert.Equal(5, list.Count);
        }
    }
}
