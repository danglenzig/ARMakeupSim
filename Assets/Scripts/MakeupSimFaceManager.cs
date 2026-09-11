using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace MakupSim
{
    [RequireComponent(typeof(ARFace))]

    public class MakeupSimFaceManager : MonoBehaviour
    {
        [SerializeField] private List<MakeupSimFaceLayer> _layers;

        //private Mesh _mesh;
        private ARFace _face;
        private bool _topologyUpdatedThisFrame = false;


        private void OnValidate()
        {
            //
        }

        private void Awake()
        {
            //_mesh = new Mesh();
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

        void Start()
        {

        }

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

            foreach(MakeupSimFaceLayer layer in _layers)
            {
                layer.SetLayerVisibility(visible, _face);
            }
        }

        private void OnUpdated(ARFaceUpdatedEventArgs eventArgs)
        {
            UpdateVisibility();

            if (!_topologyUpdatedThisFrame)
            {
                // SetMeshTopology on all the layers
                foreach(MakeupSimFaceLayer layer in _layers)
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


