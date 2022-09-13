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
            _settings = new Settings();
        }

        [Fact]
        public void PlayerMoves()
        {
            
            int positionTop = _player.PositionTop;
            int positionLeft = _player.PositionLeft;

            //act
            _player.MoveVertical(_settings.MOVEMENT_DISTANCE);
            _player.MoveHorizontal(_settings.MOVEMENT_DISTANCE);

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
