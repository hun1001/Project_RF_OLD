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
        private Transform _parent;

        public override void AddItem()
        {
            _parent = transform.parent;
            _parent.TryGetComponent(out _tankDamage);

            EventManager.StartListening(EventKeyword.OnTankDamaged + transform.parent.GetComponent<Tank.Tank>().TankID, () =>
            {
                if(_tankDamage.CurrentHealthPercent <= 10f && _coroutine == null)
                {
                    _coroutine = StartCoroutine(RepairCoroutine());
                }

                else
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
                _parent.SendMessage("Repair", 0.5f, SendMessageOptions.DontRequireReceiver);
                yield return waitSeconds;
            }
        }
    }
}
