
using KjellBlazorDemo.Engine;
using KjellBlazorDemo.Engine.GameLogic;

namespace KjellBlazorDemo.EngineTests.Logic;

/// <summary>
/// TODO: make the counts dynamic based on settings
/// </summary>
public class AssettManagerTests
{
    
    [Fact]
    public void ResetAssetsResets()
    {
        //arrange
        var list = new List<Asset>();
        var settings = new Settings();
        var assetManager = new AssetManager(settings);

        //act
        assetManager.ResetAssets(list);

        //assert
        var mobs = list.Where(o => o.GetType() == typeof(Mob)).Cast<Mob>().ToList();
        var trashes = list.Where(o => o.GetType() == typeof(Trash)).Cast<Trash>().ToList();
        Assert.Single(mobs!);
        Assert.Equal(5, trashes!.Count);
    }

    [Theory] //dummy parm is just a workaround to make this run multiple times
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void DontCollideWithWall(int dummyParm)
    {
        //arrange
        var settings = new Settings();
        var am = new AssetManager(settings);
        
        List<Asset> AssetList = new();

        //act
        am.ResetAssets(AssetList);

        //assert
        Assert.False(am.DetectAnyAssetWallClipping(AssetList));

    }

    [Fact]
    public void TrashPopulates()
    {
        //arrange
        var list = new List<Asset>();
        var settings = new Settings();
        var assetManager = new AssetManager(settings);

        //act                    
        assetManager.PopulateTrash(list, 5);

        //assert
        var typedList = list.OfType<Trash>().ToList();
        Assert.Equal(5, typedList.Count);
    }

    [Fact]
    public void MobPopulates()
    {
        //arrange
        var list = new List<Asset>();
        var settings = new Settings();
        var assetManager = new AssetManager(settings);

        //act
        assetManager.PopulateMobs(list, 5);

        //assert
        var typedList = list.OfType<Mob>().ToList();
        Assert.Equal(5, typedList.Count);
    }

    [Fact]
    public void WallPopulates()
    {
        //arrange
        var list = new List<Asset>();
        var settings = new Settings();
        var assetManager = new AssetManager(settings);

        //act
        assetManager.PopulateWalls(list, 2, 5);
        var typedList = list.OfType<Wall>().ToList();

        //assert total 10 wall units, 2 groupings of 5
        // *2 cause it now does vertial and horizontal
        Assert.Equal(20, typedList.Count); 
    }

}
