using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Util;

namespace Tank
{
    public class Tank_Skill : Base.CustomComponent<Tank>
    {
        private bool _isSkill = false;

        protected override void Assignment()
        {
            
        }
        
        public void Skill()
        {
            _isSkill = true;
        }

        private void Update()
        {
            if (_isSkill && Input.GetMouseButtonDown(0))
            {
                _isSkill = false;
                if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                //     IEnumerator exC()
                //     {
                //         float[] missileTime = new float[3];
                //
                //         for (int i = 0; i < 3; i++)
                //         {
                //             missileTime[i] = Random.Range(0.5f, 10f);
                //         }
                //         
                //         for (int i = 0; i < 3; i++)
                //         {
                //             for (int j = 0; j < 3; j++)
                //             {
                //                 if (missileTime[i] < missileTime[j])
                //                 {
                //                     (missileTime[i], missileTime[j]) = (missileTime[j], missileTime[i]);
                //                 }
                //             }
                //         }
                //         
                //         for (int i = 0; i < 3; i++)
                //         {
                //             yield return new WaitForSeconds(missileTime[0]);
                //             Debug.Log($"Missile {i} to {hit.point}");
                            PoolManager.Instance.Get("Assets/Prefabs/Effect/WFXMR_ExplosiveSmokeGround Big.prefab", hit.point + Vector3.up, Quaternion.identity);
                    //     }
                    // }

                   // StartCoroutine(exC());
                }
            }
        }
    }
}
