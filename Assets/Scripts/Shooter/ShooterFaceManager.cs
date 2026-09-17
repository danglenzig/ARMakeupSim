
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Events;
using UnityRandom = UnityEngine.Random;

namespace Shooter
{
    [RequireComponent(typeof(ARFace))]

    public class ShooterFaceManager : MonoBehaviour
    {
        //[SerializeField] private SO_EventFloatPayload _fuckYouEvent;

        [SerializeField] private List<ShooterFaceLayer> _layers;
        private ARFace _face;
        private bool _topologyUpdatedThisFrame = false;

        private void Awake()
        {
            _face = GetComponent<ARFace>();
        }

        private void OnEnable()
        {
            _face.updated += OnUpdated;
            ARSession.stateChanged += OnSessionStateChanged;
            UpdateVisibility();
        }
        private void OnDisable()
        {
            _face.updated -= OnUpdated;
            ARSession.stateChanged -= OnSessionStateChanged;
        }

        /*
        void Start()
        {

        }
        */

        /*
        void Update()
        {

        }
        */

        private void UpdateVisibility()
        {
            bool visible = enabled &&
                (_face.trackingState != TrackingState.None) &&
                (ARSession.state > ARSessionState.Ready);

            foreach (ShooterFaceLayer layer in _layers)
            {
                layer.SetLayerVisibility(visible, _face);
                //layer.SetLayerVisibility(true, _face);
            }
        }

        private void OnUpdated(ARFaceUpdatedEventArgs eventArgs)
        {
            

            UpdateVisibility();

            if (!_topologyUpdatedThisFrame)
            {
                // SetMeshTopology on all the layers
                foreach (ShooterFaceLayer layer in _layers)
                {


                    layer.SetMeshTopology(_face);
                }
                _topologyUpdatedThisFrame = true;
            }
            _topologyUpdatedThisFrame = false;
        }

        private void OnSessionStateChanged(ARSessionStateChangedEventArgs eventArgs)
        {
            UpdateVisibility();
        }

    }
}


