using Util;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private bool _isStop = false;
        public bool IsStop
        {
            get
            {
                return _isStop;
            }
            set
            {
                _isStop = value;
            }
        }

        private void Awake()
        {
            Application.targetFrameRate = 120;
            PlayerPrefs.SetInt("Gold", 100);
            PlayerPrefs.SetInt("Destroy", 0);
        }
    }
}
