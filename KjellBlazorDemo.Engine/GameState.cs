using KjellBlazorDemo.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.Engine
{
    public class GameState : IGameState
    {

        private readonly IPlayer _player;

        public GameState(IPlayer player)
        {
            _player = player;
        }

        
    }
}
