using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KjellBlazorDemo.Engine;
using KjellBlazorDemo.Engine.Interfaces;

namespace KjellBlazorDemo.EngineTests
{
    public class PlayerManagerTests
    {

        private PlayerManager _player;
        private Settings _settings;

        public PlayerManagerTests()
        {
            _settings = new Settings();
            _player = new PlayerManager(_settings);
        }

        [Fact]
        public void PlayerMoves()
        {
            
            Point pnt = new Point(_player.Position.X, _player.Position.Y);

            //act
            _player.MoveDown();
            _player.StopVerticalMovement();
            _player.MoveRight();
            _player.StopHorizontalMovement();
            
            //assert
            Assert.Equal(_player.Position.Y, pnt.Y + _settings.MOVEMENT_DISTANCE);
            Assert.Equal(_player.Position.X, pnt.X + _settings.MOVEMENT_DISTANCE);

        }

        [Fact]
        public void PlayerToString()
        {
            //confirm that player torstring returns the name + coordinates
            string tostring = String.Concat(_player.Character.Name, " (",
                _player.Position.X.ToString(), ",",
                _player.Position.Y.ToString(), ")");

            Assert.Equal(tostring, _player.ToString());

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
            _player.TeleportRandom();

            //assert
            Assert.False(_player.DetectClipping());

        }


    }
}
