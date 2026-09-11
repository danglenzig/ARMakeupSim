using System.Collections.Generic;
using Events;
using MiscTools;
using NUnit.Framework;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

namespace MakupSim
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private SO_EventStringListPayload _interactionEvent;
        [SerializeField] private GameObject _welcomeUI;
        [SerializeField] private GameObject _inGameUI;
        [SerializeField] private GameObject _layersUI;
        [SerializeField] private GameObject _layerButtons;
        [SerializeField] private GameObject _layerMenus;
        [SerializeField] private GameObject _lipsMenu;
        [SerializeField] private Button _lipsSizeButton;
        [SerializeField] private Button _lipsColorButton;
        [SerializeField] private Button _welcomeContinueButton;
        [SerializeField] private Button _layersButton;
        [SerializeField] private Button _lipsMenuButton;

        private void OnValidate()
        {
            // ...
        }
        private void Awake()
        {
            //
        }
        private void OnEnable()
        {
            _welcomeUI.SetActive(true);
            _inGameUI.SetActive(false);
            _layersUI.SetActive(false);

            _welcomeContinueButton.onClick.AddListener(HandleWelcomeContinueButtonClicked);
            _layersButton.onClick.AddListener(HandleLayersButtonClicked);

            _lipsMenuButton.onClick.AddListener(HandleLipsMenuButtonClicked);
            _lipsSizeButton.onClick.AddListener(HandleLipsSizeButtonPressed);
            _lipsColorButton.onClick.AddListener(HandleLipsColorButtonPressed);
            
        }
        private void OnDisable()
        {
            _welcomeContinueButton.onClick.RemoveAllListeners();
            _layersButton.onClick.RemoveAllListeners();
            _lipsMenuButton.onClick.RemoveAllListeners();
            _lipsSizeButton.onClick.RemoveAllListeners();
            _lipsColorButton.onClick.RemoveAllListeners();
        }
        void Start()
        {

        }

        // input event handlers
        private void HandleWelcomeContinueButtonClicked()
        {
            _welcomeUI.SetActive(false);
            _inGameUI.SetActive(true);
        }

        private void HandleLayersButtonClicked()
        {
            _layersUI.SetActive(!_layersUI.activeSelf);

            // resets the layer menu view
            _layerButtons.SetActive(true);
            HideAllLayerMenus();
        }

        private void HandleLipsMenuButtonClicked()
        {
            //List<string> tags = new List<string>() { "LAYER", "LIPS" };
            //_interactionEvent.TriggerEvent(tags);
            //Debug.Log($"### {name}: Cycle lips button clicked. Tags: {StringTools.StringListToString(tags)}");

            // Hide the buttons
            _layerButtons.SetActive(false);
            _lipsMenu.SetActive(true);
        }

        private void HandleLipsSizeButtonPressed()
        {
            List<string> tags = new List<string>() { "LAYER", "LIPS", "SIZE" };
            _interactionEvent.TriggerEvent(tags);
            //Debug.Log($"### {name}: Lips size button clicked. Tags: {StringTools.StringListToString(tags)}");
        }

        private void HandleLipsColorButtonPressed()
        {
            List<string> tags = new List<string>() { "LAYER", "LIPS", "COLOR" };
            _interactionEvent.TriggerEvent(tags);
        }

        private void HideAllLayerMenus()
        {
            Transform[] menuTransforms = _layerMenus.GetComponentsInChildren<Transform>();
            foreach (Transform t in menuTransforms)
            {
                if (t.tag == "LayerMenu")
                {
                    t.gameObject.SetActive(false);
                }
                
            }
        }

    }
}


