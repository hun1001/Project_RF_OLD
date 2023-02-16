using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine.AI;
using Sound;
using UnityEngine;

namespace Tank
{
    public class Tank_Move : Base.CustomComponent<Tank>
    {
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

        protected void Assignment()
        {
            _rigidbody = Instance.GetComponent<Rigidbody>();
            _moveSound = SoundManager.Instance.LoopPlaySound(Instance._moveSound, SoundType.SFX, 0.6f);
            _trackSound = SoundManager.Instance.LoopPlaySound(Instance._trackSound, SoundType.SFX, 0.3f, 0f);

            _maxSpeed = Instance.TankSO.maxSpeed;
            _acceleration = Instance.TankSO.acceleration;
            _rotationSpeed = Instance.TankSO.rotationSpeed;

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
                    SoundManager.Instance.PlaySound(Instance._loadSound, SoundType.SFX, 0.4f);
                }

                if(_currentSpeed != _maxSpeed)
                {
                    float pitch = (_currentSpeed * 2f) / _maxSpeed;
                    _moveSound.PitchSetting(pitch);
                    if (pitch < 0.1f) pitch = 0f;
                    _trackSound.PitchSetting(pitch);
                }
            }
            else
            {
                _currentSpeed -= _acceleration * Time.deltaTime * 2f;
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
                Instance.LineRenderer[0].SetPosition(_currentSkidMark, Instance.SkidMark[0].position + new Vector3(0,0.1f,0));
                Instance.LineRenderer[1].SetPosition(_currentSkidMark, Instance.SkidMark[1].position + new Vector3(0, 0.1f, 0));
                if(Instance.LineRenderer[0].positionCount > 100)
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
                Debug.DrawLine(transform.position + transform.forward * _currentSpeed * Time.deltaTime, transform.position + transform.forward * _currentSpeed * Time.deltaTime + Vector3.up * 50f, Color.red);
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
    }
}
