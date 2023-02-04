using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private void Awake()
        {
            Application.targetFrameRate = 120;
        }
    }
}
