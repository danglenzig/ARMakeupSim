using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Events;
using UnityEngine.XR.ARSubsystems;

namespace MakupSim
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent (typeof(MeshRenderer))]
    public class MakeupSimFaceLayer : MonoBehaviour
    {

        [SerializeField] private List<Material> _mats;
        [SerializeField] private SO_EventStringListPayload _interactionEvent;
        [SerializeField] private string _tagString;
        [SerializeField] private bool _canChangeSize = false;
        [SerializeField] private bool _canChangeColor = false;
        [SerializeField] private List<Color> _colors;
        
        private MeshFilter _meshFilter;
        private Mesh _mesh;
        private MeshRenderer _meshRenderer;
        private int _sizeMatIdx = 0;
        private int _colorIdx = 0;

        private void OnValidate()
        {
            //
        }

        private void Awake()
        {
            _mesh = new Mesh();
            _meshFilter = GetComponent<MeshFilter>();
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void OnEnable()
        {
            if (FaceConfigService.Instance != null)
            {
                _sizeMatIdx = FaceConfigService.Instance.FaceConfig.GetSizeIdx(_tagString);
                _colorIdx = FaceConfigService.Instance.FaceConfig.GetColorIdx(_tagString);
            }

            SetColor();
            SetSizeMat();

            _interactionEvent.OnEventTriggered += HandleInteractionEvent;


        }

        private void OnDisable()
        {
            _interactionEvent.OnEventTriggered -= HandleInteractionEvent;
        }

        void Start()
        {

        }

        /*
        void Update()
        {

        }
        */

        private void HandleInteractionEvent(List<string> eventTags)
        {
            if (eventTags[0] != "LAYER") return;

            if (eventTags[1] != _tagString) return;

            if (_canChangeSize && eventTags[2] == "SIZE")
            {
                CycleSizeMats();
                return;
            }

            if (_canChangeSize && eventTags[2] == "COLOR")
            {
                CycleColors();
                return;
            }
        }

        private void CycleColors()
        {
            // cycle through the colors
            int newIdx = (_colorIdx + 1) % _colors.Count;
            _colorIdx = newIdx;
            SetColor();

            if (FaceConfigService.Instance == null)
            {
                Debug.LogWarning($"### {name}: where's the singleton?");
                return;
            }

            FaceConfigService.Instance.FaceConfig.SetLipsColorIdx(_colorIdx);

            
        }

        private void CycleSizeMats()
        {
            // cycle through the materials, which will be different sizes of the thing
            int newIdx = (_sizeMatIdx + 1) % _mats.Count;
            _sizeMatIdx = newIdx;            
            SetSizeMat();

            if (FaceConfigService.Instance == null)
            {
                Debug.LogWarning($"### {name}: where's the singleton?");
                return;
            }

            FaceConfigService.Instance.FaceConfig.SetLipsSizeIdx(_sizeMatIdx);

        }

        private void SetSizeMat()
        {
            Debug.Log($"### {name}: Size mat idx: {_sizeMatIdx}");
            _meshRenderer.material = _mats[_sizeMatIdx];
        }
        private void SetColor()
        {
            Debug.Log($"### {name}: Color idx: {_colorIdx}");
            Material mat = _meshRenderer.material;
            mat.SetColor("_BaseColor", _colors[_colorIdx]);
        }

        //=====
        // API
        //=====

        public void SetLayerVisibility(bool val, ARFace face)
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            if (_meshRenderer == null) return;

            // if it is getting visible after being invisible for a while,
            // set its topology
            if (val && !_meshRenderer.enabled)
            {
                SetMeshTopology(face);
            }
            _meshRenderer.enabled = val;
        }

        public void SetMeshTopology(ARFace face)
        {
            // clear the mesh
            _mesh.Clear();

            if (face.vertices.Length > 0 && face.indices.Length > 0)
            {
                _mesh.SetVertices(face.vertices);
                _mesh.SetIndices(face.indices, MeshTopology.Triangles, 0, false);
                _mesh.RecalculateBounds();
                
                if (face.normals.Length == face.vertices.Length)
                {
                    _mesh.SetNormals(face.normals);
                }
                else
                {
                    _mesh.RecalculateNormals();
                }
            }

            if (face.uvs.Length > 0)
            {
                _mesh.SetUVs(0, face.uvs);
            }

            _meshFilter = GetComponent<MeshFilter>();
            if (_meshFilter != null)
            {
                _meshFilter.sharedMesh = _mesh;
            }

        }
    }
}

