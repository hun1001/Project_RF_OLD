using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Item
{
    public class Item_Machingun : Item
    {
        protected int _maxMagazine = 50;
        protected int _currentMagazine = 0;

        private float _range = 20f;
        private float _angle = 70f;
        private int _layerMask = 0;

        public override void AddItem()
        {
            transform.localPosition = new Vector3(0f, 2f, 4f);
            transform.localRotation = Quaternion.identity;

            _currentMagazine = _maxMagazine;
            _range = 40f;
            _layerMask = 1 << LayerMask.NameToLayer("Tank");
            StartCoroutine(Shot());
        }

        private IEnumerator Shot()
        {
            WaitForSeconds reloadTime = new WaitForSeconds(4f);
            WaitForSeconds shotDelay = new WaitForSeconds(0.2f);

            Collider[] cols;
            Transform enemy;
            float nearDist;

            while (true)
            {
                yield return shotDelay;

                enemy = null;
                nearDist = Mathf.Infinity;

                // 적 탐색
                cols = Physics.OverlapSphere(transform.position, _range, _layerMask);
                for(int i = 0; i < cols.Length; i++)
                {
                    // 플레이어 제외
                    if (cols[i].CompareTag("PlayerTank")) continue;

                    Transform target = cols[i].transform;
                    Vector3 dirToTarget = (target.position - transform.position);

                    // FOV
                    // 머신건과 적 사이에 플레이어가 있으면 플레이어가 맞기에 시야각을 설정함
                    if(Vector3.Angle(transform.forward, dirToTarget.normalized) < _angle / 2)
                    {
                        // 가장 가까운 적을 때리기 위해
                        float dist = dirToTarget.sqrMagnitude;
                        if(nearDist > dist)
                        {
                            nearDist = dist;
                            enemy = target;
                        }
                    }
                }
                // 적을 찾지 못하면 재탐색
                if (enemy == null) continue;


                Quaternion dir = Quaternion.LookRotation(enemy.position - transform.position);
                dir.x = 0f;
                dir.z = 0f;
                var shell = PoolManager.Instance.Get("MachingunShell", transform.position, dir);
                shell.SendMessage("SetSpeed", 50f);
                shell.SendMessage("SetRange", 20f);

                _currentMagazine--;
                if(_currentMagazine <= 0)
                {
                    _currentMagazine = _maxMagazine;
                    yield return reloadTime;
                }
            }
        }
    }
}
