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
        private float _delay = 120f;
        
        private int _currentWave = 0;
        
        private float _gameTime = 0;

        private IEnumerator Start()
        {
            for(int i = 0;i < Instance.OpponentSO.Waves.Length; i++)
            {
                float _spawnCount = _delay / Instance.OpponentSO.Delay[i];
                for (int j = 0; j < _spawnCount; j++)
                {
                    Spawn();
                    yield return new WaitForSeconds(Instance.OpponentSO.Delay[i]);
                }
                yield return new WaitForSeconds(_delay);
                _currentWave++;
            }
        }
        
        private void Update()
        {
            _gameTime += Time.deltaTime;
        }

        private void Spawn()
        {
            for(int i = 0; i < Instance.OpponentSO.Waves[_currentWave].enemyPrefabs.Length; i++)
            {
                var _enemy = PoolManager.Instance.Get(Instance.OpponentSO.Waves[_currentWave].enemyPrefabs[i]);
            }
        }
    }
}
