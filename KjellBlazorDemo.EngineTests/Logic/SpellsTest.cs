using KjellBlazorDemo.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.EngineTests.Logic
{
    public class SpellsTest
    {
        private ISpells _spells;
        private IPlayerManager _player;
        private Settings _settings;

        public SpellsTest()
        {
            _settings = new Settings();
            _player = new PlayerManager(_settings);
            _spells = new Spells(_player, _settings);
        }

        [Fact]
        public void TeleportRandom()
        {
            //arrange
            var pnt = new Point(_player.Position.X, _player.Position.Y);

            //act
            _spells.TeleportRandom();

            //assert
            Assert.NotEqual(pnt, _player.Position);
        }

        [Fact]
        public void DontCollideWithWall()
        {
            //arrange
            var am = new AssetManager();
            List<Asset> AssetList = new();
            am.ResetAssets(AssetList);
            _player.Assets = AssetList;

            //act
            _spells.TeleportRandom();

            //assert
            Assert.False(_player.DetectClipping());

        }

        [Fact]
        public void Haste()
        {
            //arrange
            var distance = _settings.MOVEMENT_DISTANCE;

            //act
            _spells.Haste();

            //assert
            Assert.NotEqual(distance, _settings.MOVEMENT_DISTANCE);
        }

        [Fact]
        public void FireballIfMobIsPresent()
        {
            //arrange
            _player.Assets = new List<Asset>();
            
            //we couple mob and fireball here but I think that's ok
            //because they are coupled in reality, though the mob should
            //probably be more generic
            _player.Assets.Add(new Mob("troll", -8, -3, 25, 25));

            //act            
            _spells.Fireball();

            //assert
            Assert.Single(_player.Assets.Where(o => o.Name == "fireball"));
        }

        [Fact]
        public void NoFireballIfNoMob()
        {
            //arrange
            _player.Assets = new List<Asset>();

            //act
            _spells.Fireball();

            //assert
            Assert.Empty(_player.Assets);
        }

        [Fact]
        public void SummonBeast()
        {
            //arrange
            _player.Assets = new List<Asset>();

            //act
            _spells.SummonBeast();

            //assert
            Assert.Single(_player.Assets);
            Assert.IsType<Beast>(_player.Assets[0]);
        }
    }
}
