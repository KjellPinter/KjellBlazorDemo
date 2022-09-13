using System;
using System.Collections.Generic;
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
            _player = new PlayerManager();
            _settings = Engine.Settings.Instance;
        }

        [Fact]
        public void PlayerMoves()
        {
            
            int positionTop = _player.PositionTop;
            int positionLeft = _player.PositionLeft;

            //act
            _player.MoveVertical(_settings.MOVEMENT_DISTANCE, _settings.MIN_Y, _settings.MAX_Y);
            _player.MoveHorizontal(_settings.MOVEMENT_DISTANCE, _settings.MIN_X, _settings.MAX_X);

            //assert
            Assert.Equal(_player.PositionTop, positionTop + _settings.MOVEMENT_DISTANCE);
            Assert.Equal(_player.PositionLeft, positionLeft + _settings.MOVEMENT_DISTANCE);

        }

        [Fact]
        public void PlayerToString()
        {
            //confirm that player torstring returns the name + coordinates
            string tostring = String.Concat(_player.Character.Name, " (",
                _player.PositionLeft.ToString(), ",",
                _player.PositionTop.ToString(), ")");

            Assert.Equal(tostring, _player.ToString());

        }


    }
}
