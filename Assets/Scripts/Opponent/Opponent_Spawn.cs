using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Opponent
{
    public class Opponent_Spawn : Base.CustomComponent<Opponent>
    {
        private float _spawnRate = 1f;
        private float _nextSpawn = 0f;

        private void Update()
        {
            if (_nextSpawn > 0)
            {
                _nextSpawn -= Time.deltaTime;
            }
            Spawn();
        }

        public void Spawn()
        {
            if (_nextSpawn > 0)
            {
                return;
            }

            _nextSpawn = _spawnRate;

            var spawnPoint = Instance.GetRandomSpawnPoint;
            var opponentTankName = Instance.OpponentTankName[Random.Range(0, Instance.OpponentTankName.Length)];
            var opponentTank = PoolManager.Instance.Get(opponentTankName, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
