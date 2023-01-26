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
                FindMovePoint();
            }
            else
            {
                Fire();
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

            while (!_agent.CalculatePath(movePoint, path))
            {
                movePoint = movePoint.normalized * Random.Range(5f, _range);
            }
            
            _agent.SetDestination(movePoint);
        }
    }
}
