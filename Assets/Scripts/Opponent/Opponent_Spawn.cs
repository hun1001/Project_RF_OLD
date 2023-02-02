using System;
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

        private IEnumerator Start()
        {
            for(int i = 0;i < Instance.OpponentSO.Waves.Length; i++)
            {
                Spawn();
                yield return new WaitForSeconds(_delay);
            }
        }

        private void Spawn()
        {
            Debug.Log("wave " + _currentWave);  
            for (int i = 0; i < Instance.OpponentSO.Waves[_currentWave].enemyPrefabs.Length; i++)
            {
                PoolManager.Instance.Get("Assets/Prefabs/Tanks/MediumTank/Tank_M4Sherman.prefab", Instance.GetRandomSpawnPoint.position);
            }
            _currentWave++;
        }
    }
}
