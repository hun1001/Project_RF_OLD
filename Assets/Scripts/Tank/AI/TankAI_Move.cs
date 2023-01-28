using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;
using UnityEngine.AI;

namespace Tank
{
    public class TankAI_Move : Tank_Move
    {
        private NavMeshAgent _agent = null;
        private Transform _target = null;

        private float _range = 10f;

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

        protected override void Update()
        {
            if (Vector3.Distance(transform.position, _target.position) > _range)
            {
                _state = State.Move;
            }
            else
            {
                _state = State.Attack;
            }
            
            Debug.Log(_state);
        }
        
        private void LateUpdate()
        {
            switch (_state)
            {
                case State.Move:
                    _agent.SetDestination(_target.position);
                    break;
                case State.Attack:
                    _agent.SetDestination(Vector3.zero);
                    break;
            }
        }

        private void Fire()
        {
            
        }

        private void FindMovePoint()
        {
            Vector3 movePoint = _target.position - transform.position;
            movePoint = movePoint.normalized * Random.Range(5f, _range);

            NavMeshPath path = new NavMeshPath();

            //while (!_agent.CalculatePath(movePoint, path))
            {
                movePoint = movePoint.normalized * Random.Range(5f, _range);
            }
            
            _agent.SetDestination(movePoint);
        }
    }
}
