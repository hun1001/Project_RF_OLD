using UI;
using UnityEngine.AI;
using Sound;
using UnityEngine;
using Util;
using System.Collections;

namespace Tank
{
    public class Tank_Move : Base.CustomComponent<Tank>
    {
        #region Player Variable
        private Rigidbody _rigidbody = null;
        private Sound.Sound _moveSound = null;
        private Sound.Sound _trackSound = null;

        private float _currentSpeed = 0f;
        private float _maxSpeed = 0f;

        private float _currentMaxSpeed = 0f;

        private float _acceleration = 0f;

        private float _rotationSpeed = 0f;

        private int _currentSkidMark = 0;

        private bool _isMove = false;
        #endregion

        #region AI Variable

        private NavMeshAgent _agent = null;
        private Transform _target = null;

        private const float DetectionRange = 60f;
        private const float AttackRange = 20f;
        private float _aimTime = 0f;

        private bool _isAiming = false;

        private TankStateType _state = TankStateType.Idle;
        public TankStateType State => _state;
        #endregion

        private void Start()
        {
            TryGetComponent(out _rigidbody);
            TryGetComponent(out _agent);

            if (CompareTag("PlayerTank"))
            {
                PlayerStart();
            }
            else
            {
                AiStart();
            }
        }

        #region Player Function
        private void PlayerStart()
        {
            _moveSound = SoundManager.Instance.LoopPlaySound(Instance.MoveSound, SoundType.SFX, 0.6f);
            _trackSound = SoundManager.Instance.LoopPlaySound(Instance.TrackSound, SoundType.SFX, 0.3f, 0f);

            _maxSpeed = Instance.MaxSpeed;
            _acceleration = Instance.Acceleration;
            _rotationSpeed = Instance.RotationSpeed;

            _currentSpeed = 0f;

            _isMove = false;
        }

        public void Move(JoyStick moveJoystick)
        {
            if (moveJoystick.IsTouching)
            {
                _currentMaxSpeed = _maxSpeed * moveJoystick.Scalar;

                _currentSpeed += _acceleration * Time.deltaTime;
                _currentSpeed = Mathf.Clamp(_currentSpeed, 0f, _currentMaxSpeed);

                if (_isMove == false)
                {
                    _isMove = true;
                    SoundManager.Instance.PlaySound(Instance.LoadSound, SoundType.SFX, 0.4f);
                }

                if (_currentSpeed != _maxSpeed)
                {
                    float pitch = (_currentSpeed * 2f) / _maxSpeed;
                    _moveSound.PitchSetting(pitch);
                    if (pitch < 0.1f) pitch = 0f;
                    _trackSound.PitchSetting(pitch);
                }
            }
            else
            {
                _currentSpeed -= _acceleration * Time.deltaTime * 3f;
                _currentSpeed = Mathf.Clamp(_currentSpeed, 0f, _maxSpeed);
                if (_isMove == true)
                {
                    _isMove = false;
                    _moveSound.PitchSetting(0.5f);
                    _trackSound.PitchSetting(0f);
                }
            }

            if (NavMesh.SamplePosition(transform.position + transform.forward * _currentSpeed * Time.deltaTime, out NavMeshHit hit, 1f, NavMesh.AllAreas))
            {
                _rigidbody.velocity = Instance.transform.forward * _currentSpeed;
                Instance.LineRenderer[0].positionCount = _currentSkidMark + 1;
                Instance.LineRenderer[1].positionCount = _currentSkidMark + 1;
                Instance.LineRenderer[0].SetPosition(_currentSkidMark, Instance.SkidMark[0].position + new Vector3(0, 0.1f, 0));
                Instance.LineRenderer[1].SetPosition(_currentSkidMark, Instance.SkidMark[1].position + new Vector3(0, 0.1f, 0));
                if (Instance.LineRenderer[0].positionCount > 100)
                {
                    Instance.LineRenderer[0].positionCount = 101;
                    Instance.LineRenderer[1].positionCount = 101;
                    for (int i = 0; i < 100; i++)
                    {
                        Instance.LineRenderer[0].SetPosition(i, Instance.LineRenderer[0].GetPosition(i + 1));
                        Instance.LineRenderer[1].SetPosition(i, Instance.LineRenderer[1].GetPosition(i + 1));
                    }
                }
                else
                {
                    _currentSkidMark++;
                }
            }
            else
            {
                _rigidbody.velocity = Vector3.zero;
            }

            if (moveJoystick.IsTouching)
            {
                Vector3 direction = new Vector3(moveJoystick.Horizontal, 0f, moveJoystick.Vertical);
                direction.y = 0f;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                Instance.transform.rotation = Quaternion.Slerp(Instance.transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }
        }
        #endregion

        #region AI Function
        private void AiStart()
        {
            _agent.enabled = true;

            _rigidbody.mass = 1f;
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            _rigidbody.useGravity = true;

            _target = GameObject.FindGameObjectWithTag("PlayerTank").transform;

            StartCoroutine(nameof(UpdateLogic));
            StartCoroutine(nameof(LateUpdateLogic));
            StartCoroutine(nameof(Checker));

            EventManager.StartListening("OnTankDestroyed1", () =>
            {
                PoolManager.Instance.Pool(this.gameObject);
            });
        }

        private IEnumerator UpdateLogic()
        {
            while (true)
            {
                float distance = Vector3.Distance(transform.position, _target.position);
                _state = distance > DetectionRange ? TankStateType.Idle : distance > AttackRange ? TankStateType.Move : TankStateType.Attack;
                yield return null;
            }
        }

        private IEnumerator LateUpdateLogic()
        {
            while (true)
            {
                switch (_state)
                {
                    case TankStateType.Idle:
                        _agent.isStopped = true;
                        break;
                    case TankStateType.Move:
                        _agent.isStopped = false;
                        _agent.SetDestination(_target.position);
                        break;
                    case TankStateType.Attack:
                        _agent.isStopped = true;
                        break;
                }
                yield return new WaitForEndOfFrame();
            }
        }

        //private void FindMovePoint()
        //{
        //    Vector3 movePoint = _target.position - transform.position;
        //    movePoint = movePoint.normalized * Random.Range(10f, AttackRange);

        //    NavMeshPath path = new NavMeshPath();

        //    {
        //        movePoint = movePoint.normalized * Random.Range(5f, AttackRange);
        //    }

        //    _agent.SetDestination(movePoint);
        //}

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
                if (t.childCount > 0)
                    ChangeLayer(layerName, t);
            }
        }
        #endregion
    }
}
