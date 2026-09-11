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
        
        private MeshFilter _meshFilter;
        private Mesh _mesh;

        private MeshRenderer _meshRenderer;

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
            //
        }

        private void OnDisable()
        {
            //
        }

        void Start()
        {

        }

        /*
        void Update()
        {

        }
        */

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

