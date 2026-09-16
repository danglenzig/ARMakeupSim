using UnityEngine;

namespace Shooter
{
    public class Enemy : MonoBehaviour
    {
        private Vector3 _startPos = Vector3.zero;
        private bool _isEnabled = true;

        private void OnEnable()
        {
            _startPos = transform.position;
        }
        private void OnDisable()
        {
            //
        }

        void Start()
        {

        }

        void Update()
        {
            if (!_isEnabled) return;
            transform.position = _startPos;
        }
    }
}