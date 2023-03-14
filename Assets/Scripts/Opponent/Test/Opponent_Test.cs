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

        private Vector3 _hpBarOffset = new Vector3(0f, 10f, 0f);

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

            EventManager.StartListening(Keyword.EventKeyword.OnOpponentDestroyed, () =>
            {
                PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 2);
                PlayerPrefs.SetInt("Destroy", PlayerPrefs.GetInt("Destroy") + 1);
                EventManager.TriggerEvent(EventKeyword.OnUpdateGold, PlayerPrefs.GetInt("Gold"));
            });
        }

        uint _count = 2;

        private void Spawn()
        {
            for (int i = 0; i < Instance.OpponentSO.Waves[_stage].enemyPrefabs.Length; i++)
            {
                var enemy = PoolManager.Instance.Get(Instance.OpponentSO.Waves[_stage].enemyPrefabs[i], Instance.GetRandomSpawnPoint.position, Quaternion.identity);
                enemy.tag = "OpponentTank";
                enemy.TryGetComponent<Tank.Tank>(out var eT);
                eT.TankID = _count++;
                var enemyHPBar = PoolManager.Instance.Get<Bar>("Assets/Prefabs/UI/Bar/HPCanvas.prefab", enemy.transform);
                enemyHPBar.transform.localPosition = _hpBarOffset;
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
                    EventManager.TriggerEvent(Keyword.EventKeyword.OnOpponentDestroyed);

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
            _remainingEnemyText.SetText("Stage Clear!");
            _isStageClear = true;
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 10);
            FindObjectOfType<GameSceneCanvases>().ChangeCanvas(CanvasChangeType.Item, CanvasNameKeyword.PlayInformationCanvas);
            EventManager.TriggerEvent(EventKeyword.OnStageClear);
        }

        private void NextStage()
        {
            _isStageClear = false;
            _stage++;
            PlayerPrefs.SetInt("RemainingEnemy", Instance.OpponentSO.Waves[_stage].enemyPrefabs.Length);
            Spawn();
        }
    }
}
