using UI;
using UnityEngine;
using Util;

namespace Effect
{
    public class TextEffect : MonoBehaviour
    {
        private Transform _cameraTransform;

        [SerializeField]
        private TextController _text;

        private void Awake()
        {
            _cameraTransform = Camera.main.transform;
        }

        void LateUpdate()
        {
            transform.LookAt(transform.position + _cameraTransform.rotation * Vector3.forward, _cameraTransform.rotation * Vector3.up);
        }

        public void SetTextEffect(string text, Color color, float size = 1, float duration = 1f)
        {
            _text.SetText(text);
            Invoke(nameof(Pooling), duration);
        }

        private void Pooling()
        {
            PoolManager.Instance.Pool("Assets/Prefabs/UI/TextEffect.prefab", this.gameObject);
        }
    }
}