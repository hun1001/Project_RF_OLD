using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Util;

namespace Tank
{
    public class Tank_Skill : Base.CustomComponent<Tank>
    {
        [Header("Cooldown")]
        [SerializeField]
        protected float _cooldown = 0f;
        protected float _currentCooldown = 0f;

        [Header("Duration")]
        [SerializeField]
        protected float _duration = 0f;

        protected bool _isSkill = false;

        protected virtual void Awake()
        {
            _currentCooldown = 0f;
        }

        public virtual void Skill()
        {
            //if (_currentCooldown > 0f) return;
            _currentCooldown = _cooldown;
            StartCoroutine(SkillCooldown());
            if(_duration > 0f)
            {
                Invoke(nameof(Restoration), _duration);
            }
        }

        IEnumerator SkillCooldown()
        {
            while(_currentCooldown > 0f)
            {
                _currentCooldown -= Time.deltaTime;

                yield return new WaitForFixedUpdate();
            }
        }

        protected virtual void Restoration()
        {

        }

        //private void Update()
        //{
        //    if (_isSkill && Input.GetMouseButtonDown(0))
        //    {
        //        _isSkill = false;
        //        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        //        {
        //            PoolManager.Instance.Get("Assets/Prefabs/Effect/WFXMR_ExplosiveSmokeGround Big.prefab", hit.point + Vector3.up, Quaternion.identity);
        //            Collider[] colliders = Physics.OverlapSphere(hit.point, 4f);
                    
        //            foreach (var c in colliders)
        //            {
        //                if(c.CompareTag("PlayerTank") == false)
        //                {
        //                    c.SendMessage("OnHit", 600, SendMessageOptions.DontRequireReceiver);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
