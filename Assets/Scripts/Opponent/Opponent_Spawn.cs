using System;
using System.Collections;
using System.Collections.Generic;
using Item;
using UI;
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

        private UI.WaveTimer _waveTimer = null;

        private void Awake()
        {
            _waveTimer = Instance.WaveTimer;
        }

        private IEnumerator Start()
        {
            while (_currentWave < Instance.OpponentSO.Waves.Length)
            {
                Spawn();
                yield return new WaitForSeconds(Instance.OpponentSO.Delay[_currentWave]);
            }
        }

        private void Update()
        {
            _gameTime += Time.deltaTime;
            if (_gameTime >= _delay)
            {
                _gameTime = 0;
                _currentWave++;
                // TODO: 여기도 아이템 구조 한 번 더 개편하면 고쳐질 예정
                var temp = CanvasManager.Instance.GetSceneCanvases(1) as GameSceneCanvases;
                temp?.ChangeCanvas(CanvasChangeType.Item);
            }
            _waveTimer.SetTimer(_delay - _gameTime);
        }

        private void Spawn()
        {
            for(int i = 0; i < Instance.OpponentSO.Waves[_currentWave].enemyPrefabs.Length; i++)
            {
                var _enemy = PoolManager.Instance.Get(Instance.OpponentSO.Waves[_currentWave].enemyPrefabs[i], Instance.GetRandomSpawnPoint.position, Quaternion.identity);
                _enemy.tag = "OpponentTank";
            }
        }
    }
}
