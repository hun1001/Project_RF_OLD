using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Opponent
{
    public class Opponent_Spawn : Base.CustomComponent<Opponent>
    {
        [SerializeField] 
        private float _delay = 5f;
        
        private int _currentWave = 0;
        
        private void Update()
        {
            if (Time.time % _delay == 0)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            for (int i = 0; i < Instance.OpponentSO.Waves[_currentWave].enemyPrefabs.Length; i++)
            {
                PoolManager.Instance.Get("Assets/Prefabs/Tanks/MediumTank/Tank_M4Sherman.prefab", Instance.GetRandomSpawnPoint.position);
            }
            _currentWave++;
        }
    }
}
