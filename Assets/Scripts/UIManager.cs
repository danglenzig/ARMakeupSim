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

        private const string LIPS_TAG = "LIPS";
        private const string EYE_MAKEUP_TAG = "EYE_MAKEUP";

        [SerializeField] private SO_EventStringListPayload _interactionEvent;
        [SerializeField] private GameObject _welcomeUI;
        [SerializeField] private GameObject _inGameUI;
        [SerializeField] private GameObject _layersUI;
        [SerializeField] private GameObject _layerButtons;
        [SerializeField] private GameObject _layerMenus;
        [SerializeField] private GameObject _lipsMenu;
        [SerializeField] private GameObject _eyeMakeupMenu;
        [SerializeField] private Button _lipsSizeButton;
        [SerializeField] private Button _lipsColorButton;
        [SerializeField] private Button _eyeMakeupColorButton;
        [SerializeField] private Button _welcomeContinueButton;
        [SerializeField] private Button _layersButton;
        [SerializeField] private Button _lipsMenuButton;
        [SerializeField] private Button _eyeMakeupMenuButton;

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

            _eyeMakeupMenuButton.onClick.AddListener(HandleEyeMakeupMenuButtonPressed);
            _eyeMakeupColorButton.onClick.AddListener(HandleEyeMakeupColorButtonPressed);


            
        }
        private void OnDisable()
        {
            _welcomeContinueButton.onClick.RemoveAllListeners();
            _layersButton.onClick.RemoveAllListeners();
            _lipsMenuButton.onClick.RemoveAllListeners();
            _lipsSizeButton.onClick.RemoveAllListeners();
            _lipsColorButton.onClick.RemoveAllListeners();
            _eyeMakeupMenuButton.onClick.RemoveAllListeners();
            _eyeMakeupColorButton.onClick.RemoveAllListeners();
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
            // Hide the buttons
            _layerButtons.SetActive(false);
            _lipsMenu.SetActive(true);
        }

        private void HandleEyeMakeupMenuButtonPressed()
        {
            _layerButtons.SetActive(false);
            _eyeMakeupMenu.SetActive(true);
        }

        private void HandleLipsSizeButtonPressed()
        {
            List<string> tags = new List<string>() { "LAYER", LIPS_TAG, "SIZE" };
            _interactionEvent.TriggerEvent(tags);
            //Debug.Log($"### {name}: Lips size button clicked. Tags: {StringTools.StringListToString(tags)}");
        }

        private void HandleLipsColorButtonPressed()
        {
            List<string> tags = new List<string>() { "LAYER", LIPS_TAG, "COLOR" };
            _interactionEvent.TriggerEvent(tags);
        }

        private void HandleEyeMakeupColorButtonPressed()
        {
            List<string> tags = new List<string>() { "LAYER", EYE_MAKEUP_TAG, "COLOR" };
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


