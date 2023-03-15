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
            transform.parent.TryGetComponent(out _tankDamage);

            EventManager.StartListening(EventKeyword.OnTankDamaged + transform.parent.GetComponent<Tank.Tank>().TankID, () =>
            {
                if(_tankDamage.CurrentHealthPercent <= 10f && _coroutine == null)
                {
                    _coroutine = StartCoroutine(RepairCoroutine());
                }

                else if(_tankDamage.CurrentHealthPercent > 10f && _coroutine != null)
                {
                    StopCoroutine(_coroutine);
                    _coroutine = null;
                }
            });
        }

        private IEnumerator RepairCoroutine()
        {
            WaitForSeconds waitSeconds = new WaitForSeconds(1f);
            while (_tankDamage.CurrentHealthPercent <= 10f)
            {
                _tankDamage.Repair(0.5f);
                yield return waitSeconds;
            }
        }
    }
}
