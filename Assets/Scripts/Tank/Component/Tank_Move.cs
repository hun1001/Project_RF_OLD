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
        private JoyStick _joyStick = null;
        private Sound.Sound _sound = null;

        private float _currentSpeed = 0f;
        private float _maxSpeed = 0f;
        
        private float _currentMaxSpeed = 0f;

        private float _acceleration = 0f;

        private float _rotationSpeed = 0f;
        
        private int _currentSkidMark = 0;

        private bool _isMove = false;

        protected override void Assignment()
        {
            _rigidbody = Instance.GetComponent<Rigidbody>();
            _joyStick = Instance.JoyStick;
            _sound = GetComponent<Sound.Sound>();

            _maxSpeed = Instance.TankSO.maxSpeed;
            _acceleration = Instance.TankSO.acceleration;
            _rotationSpeed = Instance.TankSO.rotationSpeed;

            _currentSpeed = 0f;

            _isMove = false;
            _sound.LoopPlay(Instance._idleSound, SoundManager.Instance.GetAudioMixerGroup(SoundType.SFX));
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (_joyStick.IsTouching)
            {
                _currentMaxSpeed = _maxSpeed * _joyStick.Scalar;
                
                _currentSpeed += _acceleration * Time.deltaTime;
                _currentSpeed = Mathf.Clamp(_currentSpeed, 0f, _currentMaxSpeed);
                if(_isMove == false)
                {
                    _isMove = true;
                    _sound.LoopPlay(Instance._moveSound, SoundManager.Instance.GetAudioMixerGroup(SoundType.SFX));
                }
                if(_sound.Volume != 0.7f)
                {
                    float volume = (_currentSpeed * 0.7f) / _maxSpeed;
                    _sound.VolumeSetting(volume);
                }
            }
            else
            {
                _currentSpeed -= _acceleration * Time.deltaTime * 2f;
                _currentSpeed = Mathf.Clamp(_currentSpeed, 0f, _maxSpeed);
                if (_isMove == true)
                {
                    _isMove = false;
                    _sound.LoopPlay(Instance._idleSound, SoundManager.Instance.GetAudioMixerGroup(SoundType.SFX));
                }
            }
            
            if (NavMesh.SamplePosition(transform.position + Instance.transform.forward * _currentSpeed * Time.deltaTime, out NavMeshHit hit, 0.5f, NavMesh.AllAreas))
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
                _rigidbody.velocity = Vector3.zero;
            }

            if (_joyStick.IsTouching)
            {
                Vector3 direction = new Vector3(_joyStick.Horizontal, 0f, _joyStick.Vertical);
                direction.y = 0f;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                Instance.transform.rotation = Quaternion.Slerp(Instance.transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }
        }
    }
}
