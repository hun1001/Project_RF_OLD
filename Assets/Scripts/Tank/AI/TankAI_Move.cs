using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;
using UnityEngine.AI;
using Util;

namespace Tank
{
    public class TankAI_Move : Base.CustomComponent<Tank>
    {
        [SerializeField]
        private Transform _firePoint = null;
        
        private NavMeshAgent _agent = null;
        private Transform _target = null;

        private const float DetectionRange = 60f;
        private const float AttackRange = 20f;

        private enum State
        {
            Idle,
            Move,
            Attack,
        }
        
        private State _state = State.Idle;
        
        protected void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _target = GameObject.FindGameObjectWithTag("PlayerTank").transform;

            StartCoroutine(nameof(Checker));
        }

        private void Update()
        {
            float distance = Vector3.Distance(transform.position, _target.position);
            _state = distance > DetectionRange ? State.Idle : distance > AttackRange ? State.Move : State.Attack;
        }
        
        private void LateUpdate()
        {
            switch (_state)
            {
                case State.Idle:
                    _agent.isStopped = true;
                    break;
                case State.Move:
                    _agent.isStopped = false;
                    _agent.SetDestination(_target.position);
                    break;
                case State.Attack:
                    _agent.isStopped = true;
                    StartCoroutine(FireCoroutine());
                    break;
            }
        }

        private bool _isFire = false;

        private IEnumerator FireCoroutine()
        {
            if (_isFire == true)
            {
                yield break;
            }
            
            _isFire = true;
            
            float fireTime = 0f;

            while (_state == State.Attack)
            {
                fireTime += Time.deltaTime;
                if (fireTime > 1f)
                {
                    fireTime = 0f;
                    var shell = PoolManager.Instance.Get("Assets/Prefabs/Shell/Shell.prefab", _firePoint.position, _firePoint.rotation);
                    shell.SendMessage("SetSpeed", 20f);
                    shell.SendMessage("SetRange", 20f);
                }
                yield return null;
            }
            
            _isFire = false;
        }

        private void FindMovePoint()
        {
            Vector3 movePoint = _target.position - transform.position;
            movePoint = movePoint.normalized * Random.Range(10f, AttackRange);

            NavMeshPath path = new NavMeshPath();

            {
                movePoint = movePoint.normalized * Random.Range(5f, AttackRange);
            }
            
            _agent.SetDestination(movePoint);
        }
        
        private bool _isAiming = false;

        private float _aimTime = 0f;
        
        private void Aiming()
        {
            _isAiming = true;
            StopCoroutine(nameof(AimingCheck));
            StartCoroutine(nameof(AimingCheck));
        }
        
        private IEnumerator AimingCheck()
        {
            _aimTime = 0f;
            while (_aimTime < 0.1f)
            {
                _aimTime += Time.deltaTime;
                yield return null;
            }
            _isAiming = false;
        }

        private IEnumerator Checker()
        {
            while (true)
            {
                ChangeLayer(_isAiming ? "OutLine" : "Default", transform);
                yield return null;
            }
        }
        
        private void ChangeLayer(string layerName, Transform objTransform)
        {
            foreach (Transform t in objTransform)
            {
                t.gameObject.layer = LayerMask.NameToLayer(layerName);
                if(t.childCount > 0)
                    ChangeLayer(layerName, t);
            }
        }
    }
}