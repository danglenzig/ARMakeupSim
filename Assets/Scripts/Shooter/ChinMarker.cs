using UnityEngine;
using Events;

namespace Shooter
{
    public class ChinMarker : MonoBehaviour
    {

        [SerializeField] SO_EventFloatPayload _chinUpdateEvent;
        const float _updateInterval = 0.05f;

        private bool _isEnabled = true;

        private Camera _cammy;

        private float _ta = 0.0f;


        private void Awake()
        {
            if (_cammy == null)
            {
                _cammy = Camera.main;
            }
        }

        private void OnEnable()
        {
            _ta = 0.0f;
        }

        private void OnDisable()
        {
            
        }

        private void Update()
        {
            if (!_isEnabled) return;

            _ta += Time.deltaTime;
            if (_ta < _updateInterval) return;
            
            _ta = 0.0f;
            _chinUpdateEvent.TriggerEvent(GetChinHorizontal());

        }

        private float GetChinHorizontal()
        {
            if (_cammy == null)
            {
                _cammy = Camera.main;
                if (_cammy == null) return 0f;
            }

            // Convert the 3D world position of the chin to Screen Viewport Coordinates.
            // Viewport Space is normalized: (0,0) is bottom-left, (1,1) is top-right.
            Vector3 viewportPoint = _cammy.WorldToViewportPoint(transform.position);
            return viewportPoint.x;

        }

    }
}


