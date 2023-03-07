using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opponent
{
    public class NextStage : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("PlayerTank"))
            {
                if(PlayerPrefs.GetInt("RemainingEnemy") <= 0)
                {
                    EventManager.TriggerEvent(Keyword.EventKeyword.OnStageClear);
                }
            }
        }
    }
}
