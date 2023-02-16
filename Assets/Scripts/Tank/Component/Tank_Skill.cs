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
                    PoolManager.Instance.Get("Assets/Prefabs/Effect/WFXMR_ExplosiveSmokeGround Big.prefab", hit.point + Vector3.up, Quaternion.identity);
                    Collider[] colliders = Physics.OverlapSphere(hit.point, 4f);
                    
                    foreach (var c in colliders)
                    {
                        if(c.CompareTag("PlayerTank") == false)
                        {
                            c.SendMessage("OnHit", 600, SendMessageOptions.DontRequireReceiver);
                        }
                    }
                }
            }
        }
    }
}
