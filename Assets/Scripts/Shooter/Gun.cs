using UnityEngine;

namespace Shooter
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Gun : MonoBehaviour
    {

        private bool _isEnabled = true;

        Vector3 _startPos = Vector3.zero;

        private void OnEnable()
        {
            _startPos = transform.position;
        }
        private void OnDisable()
        {
            
        }


        void Start()
        {

        }
        void Update()
        {
            if (!_isEnabled) return;
            Vector3 pos = new Vector3(transform.position.x, _startPos.y, _startPos.z);
            transform.position = pos;
        }
    }
}