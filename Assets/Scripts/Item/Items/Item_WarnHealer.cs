using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank;
using Keyword;

namespace Item
{
    public class Item_WarnHealer : Item
    {
        private Tank_Damage _tankDamage = null;
        private Coroutine _coroutine = null;

        public override void AddItem()
        {
            _tankDamage = transform.parent.GetComponent<Tank_Damage>();

            EventManager.StartListening(EventKeyword.OnTankDamaged + transform.parent.GetComponent<Tank.Tank>().TankID, () =>
            {
                if(_tankDamage.CurrentHealthPercent <= 10f && _coroutine == null)
                {
                    _coroutine = StartCoroutine(RepairCoroutine());
                }
            });
        }

        private IEnumerator RepairCoroutine()
        {
            WaitForSeconds waitSeconds = new WaitForSeconds(1f);
            while (_tankDamage.CurrentHealthPercent <= 10f)
            {
                transform.parent.SendMessage("Repair", 0.5f, SendMessageOptions.DontRequireReceiver);
                yield return waitSeconds;
            }
        }
    }
}
