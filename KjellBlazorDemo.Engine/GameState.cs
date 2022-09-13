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

        private readonly IPlayerManager _player;

        public GameState(IPlayerManager player)
        {
            _player = player;
        }

        
    }
}
