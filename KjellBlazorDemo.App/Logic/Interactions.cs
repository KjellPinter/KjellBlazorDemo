﻿using KjellBlazorDemo.App.Models;
using KjellBlazorDemo.Engine;
using KjellBlazorDemo.Engine.Interfaces;

namespace KjellBlazorDemo.App.Logic
{
    public class Interactions
    {

        private IPlayerManager _player = null!;
        private List<Asset> _assetList = null!;

        internal void CollisionDetect(List<Asset> AssetList, IPlayerManager Player)
        {
            _player = Player;
            _assetList = AssetList;

            RemoveTrashWhichTouchesPlayer();
            MoveMobTowardsPlayer();
        }

        internal void RemoveTrashWhichTouchesPlayer()
        {
            var cols = _assetList.Where(o => o.Left > (_player.PositionLeft - 34) && o.Left < (_player.PositionLeft) + 2
                            && o.Top > (_player.PositionTop - 34) && o.Top < (_player.PositionTop) + 2).ToList();

            foreach (var c in cols)
            {
                _assetList.Remove(c);
            }
        }

        internal void MoveMobTowardsPlayer()
        {
            Mob? mob = (Mob?)_assetList.Where(o => o.GetType() == typeof(Mob)).FirstOrDefault();

            if (mob is not null)
            {
                if (mob.Top < _player.PositionTop)
                {
                    ++mob.Top;
                }

                if (mob.Top > _player.PositionTop)
                {
                    --mob.Top;
                }

                if (mob.Left < _player.PositionLeft)
                {
                    ++mob.Left;
                }

                if (mob.Left > _player.PositionLeft)
                {
                    --mob.Left;
                }
            }
        }


    }
}
