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

        private float _range = 15f;

        private bool _isMove = false;

        public enum State
        {
            Move,
            Attack,
        }
        
        private State _state = State.Move;
        
        protected override void Assignment()
        {
            base.Assignment();
            _agent = GetComponent<NavMeshAgent>();
            _target = GameObject.FindGameObjectWithTag("PlayerTank").transform;
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _target.position) > _range)
            {
                _state = State.Move;
            }
            else
            {
                _state = State.Attack;
            }
        }
        
        private void LateUpdate()
        {
            switch (_state)
            {
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
                Debug.Log(fireTime);
                if (fireTime > 5f)
                {
                    Debug.Log("Fire");
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
            movePoint = movePoint.normalized * Random.Range(10f, _range);

            NavMeshPath path = new NavMeshPath();

            //while (!_agent.CalculatePath(movePoint, path))
            {
                movePoint = movePoint.normalized * Random.Range(5f, _range);
            }
            
            _agent.SetDestination(movePoint);
        }
    }
}