using System.Collections;
using System.Collections.Generic;
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

        private TextController _waveTimer = null;

        private void Awake()
        {
            _waveTimer = Instance.WaveTimer;
        }

        private void Start()
        {
            StartCoroutine(nameof(SpawnCoroutine));
            StartCoroutine(nameof(UpdateLogic));
            EventManager.StartListening(Keyword.EventKeyword.OnTankDestroyed + 1, () =>
            {
                StopCoroutine(nameof(SpawnCoroutine));
                StopCoroutine(nameof(UpdateLogic));
            });
        }

        private IEnumerator SpawnCoroutine()
        {
            while (_currentWave < Instance.OpponentSO.Waves.Length)
            {
                Spawn();
                yield return new WaitForSeconds(Instance.OpponentSO.Delay[_currentWave]);
            }
        }

        private IEnumerator UpdateLogic()
        {
            while (true)
            {
                _gameTime += Time.deltaTime;
                if (_gameTime >= _delay)
                {
                    _gameTime = 0;
                    _currentWave++;
                    FindObjectOfType<GameSceneCanvases>().ChangeCanvas(CanvasChangeType.Item);
                }
                _waveTimer.SetText(string.Format("Next Wave\n{0:0.0}", _delay - _gameTime));
                yield return null;
            }
        }

        uint _count = 2;

        private void Spawn()
        {
            for (int i = 0; i < Instance.OpponentSO.Waves[_currentWave].enemyPrefabs.Length; i++)
            {
                var enemy = PoolManager.Instance.Get(Instance.OpponentSO.Waves[_currentWave].enemyPrefabs[i], Instance.GetRandomSpawnPoint.position, Quaternion.identity);
                enemy.tag = "OpponentTank";
                var eT = enemy.GetComponent<Tank.Tank>();
                eT.TankID = _count++;
                var enemyHPBar = PoolManager.Instance.Get<Bar>("Assets/Prefabs/UI/Bar/HPCanvas.prefab", enemy.transform);
                enemyHPBar.transform.localPosition = new Vector3(0, 10f, 0);
                enemyHPBar.MaxValue = eT.Hp;

                EventManager.StartListening(Keyword.EventKeyword.OnTankDamaged + eT.TankID, (dmg) =>
                {
                    float damage = (float)dmg[0];
                    enemyHPBar.Value -= damage;
                });
            }
        }
    }
}
