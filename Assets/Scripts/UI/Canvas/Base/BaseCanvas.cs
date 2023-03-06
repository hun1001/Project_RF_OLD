using Base;
using UnityEngine;

namespace UI
{
    public abstract class BaseCanvas : MonoActiveEventBehaviour
    {
        public string CanvasName => gameObject.name;

        private Canvas _canvas = null;

        protected virtual void Awake()
        {
            _canvas = GetComponent<Canvas>();
            // 이거 MonoActiveEventBehaviour에서 해주는게 좋을듯 같은거 상속받은 다른 클래스에도 중복됨
            OnEnableAction += () => _canvas.enabled = true;
            OnDisableAction += () => _canvas.enabled = false;

            OnEnableAction += SetOnEnableAction;
            OnDisableAction += SetOnDisableAction;
        }

        protected abstract void SetOnEnableAction();
        protected abstract void SetOnDisableAction();
    }
}
