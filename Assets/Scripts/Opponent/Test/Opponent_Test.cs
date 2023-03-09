using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using Util;
using Keyword;

namespace Opponent
{
    public class Opponent_Test : Base.CustomComponent<Opponent>
    {
        private int _stage = 0;
        private bool _isStageClear = false;

        private TextController _remainingEnemyText = null;

        private void Awake()
        {
            _remainingEnemyText = Instance.WaveTimer;
            PlayerPrefs.SetInt("RemainingEnemy", Instance.OpponentSO.Waves[_stage].enemyPrefabs.Length);

            Spawn();
            EventManager.StartListening(Keyword.EventKeyword.OnStageClear, () =>
            {
                if(_isStageClear == true)
                {
                    NextStage();
                }
            });
        }

        uint _count = 2;

        private void Spawn()
        {
            for (int i = 0; i < Instance.OpponentSO.Waves[_stage].enemyPrefabs.Length; i++)
            {
                var enemy = PoolManager.Instance.Get(Instance.OpponentSO.Waves[_stage].enemyPrefabs[i], Instance.GetRandomSpawnPoint.position, Quaternion.identity);
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
                EventManager.StartListening(Keyword.EventKeyword.OnTankDestroyed + eT.TankID, () =>
                {
                    PlayerPrefs.SetInt("RemainingEnemy", PlayerPrefs.GetInt("RemainingEnemy") - 1);
                    _remainingEnemyText.SetText(string.Format("Remaining Enemy\n{0:0}", PlayerPrefs.GetInt("RemainingEnemy")));

                    if(PlayerPrefs.GetInt("RemainingEnemy") <= 0)
                    {
                        StageClear();
                    }
                });
            }
            _remainingEnemyText.SetText(string.Format("Remaining Enemy\n{0:0}", PlayerPrefs.GetInt("RemainingEnemy")));
        }

        private void StageClear()
        {
            FindObjectOfType<GameSceneCanvases>().ChangeCanvas(CanvasChangeType.Item, CanvasNameKeyword.PlayInformationCanvas);
            _isStageClear = true;
            Debug.Log("Stage Clear!");
        }

        private void NextStage()
        {
            _isStageClear = false;
            _stage++;
            PlayerPrefs.SetInt("RemainingEnemy", Instance.OpponentSO.Waves[_stage].enemyPrefabs.Length);
            Debug.Log("Next Stage!!");
            Spawn();
        }
    }
}
