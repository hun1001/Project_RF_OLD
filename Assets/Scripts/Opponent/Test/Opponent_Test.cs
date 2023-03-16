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
            EventManager.StartListening(EventKeyword.OnStageClear, () =>
            {
                if(_isStageClear == true)
                {
                    NextStage();
                }
            });

            EventManager.StartListening(EventKeyword.OnOpponentDestroyed, () =>
            {
                PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 2);
                PlayerPrefs.SetInt("Destroy", PlayerPrefs.GetInt("Destroy") + 1);
                EventManager.TriggerEvent(EventKeyword.OnUpdateGold, PlayerPrefs.GetInt("Gold"));
            });
        }

        uint _count = 2;

        private void Spawn()
        {
            Transform[] list = Instance.GetsSpawnPoint(Instance.SpawnPointParent[_stage % 3]);
            for (int i = 0; i < Instance.OpponentSO.Waves[_stage].enemyPrefabs.Length; i++)
            {
                var enemy = PoolManager.Instance.Get(Instance.OpponentSO.Waves[_stage].enemyPrefabs[i], Instance.GetRandomSpawnPoint(list).position, Quaternion.identity);
                enemy.tag = "OpponentTank";
                enemy.TryGetComponent<Tank.Tank>(out var eT);
                eT.TankID = _count++;
                var enemyHpBar = PoolManager.Instance.Get<Bar>("Assets/Prefabs/UI/Bar/HPCanvas.prefab", enemy.transform);
                enemyHpBar.transform.localPosition = _hpBarOffset;
                enemyHpBar.MaxValue = eT.Hp;
                EventManager.StartListening(Keyword.EventKeyword.OnTankDamaged + eT.TankID, (dmg) =>
                {
                    float damage = (float)dmg[0];
                    enemyHpBar.Value -= damage;

                    if (enemyHpBar.Value <= 0f)
                    {
                        EventManager.TriggerEvent(EventKeyword.OnTankDestroyed + eT.TankID);
                    }
                });
                EventManager.StartListening(EventKeyword.OnTankDestroyed + eT.TankID, () =>
                {
                    PlayerPrefs.SetInt("RemainingEnemy", PlayerPrefs.GetInt("RemainingEnemy") - 1);
                    _remainingEnemyText.SetText(string.Format("Remaining Enemy\n{0:0}", PlayerPrefs.GetInt("RemainingEnemy")));
                    EventManager.TriggerEvent(Keyword.EventKeyword.OnOpponentDestroyed);

                    if(PlayerPrefs.GetInt("RemainingEnemy") <= 0)
                    {
                        StageClear();
                    }
                    PoolManager.Instance.Pool(enemy);
                });
            }
            _remainingEnemyText.SetText(string.Format("Remaining Enemy\n{0:0}", PlayerPrefs.GetInt("RemainingEnemy")));
            GameObject.Find("Player").GetComponent<Transform>().GetChild(0).position = Instance.PlayerSpawnPoint[_stage % 3].position;
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
            if(Instance.OpponentSO.Waves.Length <= _stage)
            {
                FindObjectOfType<GameSceneCanvases>().ChangeCanvas(CanvasChangeType.Result, CanvasNameKeyword.PlayInformationCanvas);
                return;
            }
            Spawn();
        }
    }
}
