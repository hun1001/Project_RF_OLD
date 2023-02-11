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
        
        private Material _aimMaterial = null;

        public enum State
        {
            Move,
            Attack,
        }
        
        private State _state = State.Move;
        
        protected override void Assignment()
        {
            base.Assignment();
            _aimMaterial = AddressablesManager.Instance.GetMaterial("Assets/Shader/OutLine/OutLine.mat");
            _agent = GetComponent<NavMeshAgent>();
            _target = GameObject.FindGameObjectWithTag("PlayerTank").transform;

            StartCoroutine(nameof(Checker));
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
                if (fireTime > 5f)
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
            movePoint = movePoint.normalized * Random.Range(10f, _range);

            NavMeshPath path = new NavMeshPath();

            //while (!_agent.CalculatePath(movePoint, path))
            {
                movePoint = movePoint.normalized * Random.Range(5f, _range);
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
        
        MeshRenderer[] _meshRenderer = null;
        
        private Material[] _defaultMaterials = null;
        
        private IEnumerator Checker()
        {
            _meshRenderer = GetComponentsInChildren<MeshRenderer>();
            _defaultMaterials = new Material[_meshRenderer.Length];
            for (int i = 0; i < _meshRenderer.Length; i++)
            { 
                _defaultMaterials[i] = _meshRenderer[i].material;
            }
            
            while (true)
            {
                if (_isAiming)
                {
                    for (int i = 0; i < _meshRenderer.Length; i++)
                    {
                        _meshRenderer[i].material = _aimMaterial;
                    }
                }
                else
                {
                    for (int i = 0; i < _meshRenderer.Length; i++)
                    {
                        _meshRenderer[i].material = _defaultMaterials[i];
                    }
                }
                
                yield return null;
            }
            yield break;
        }
    }
}