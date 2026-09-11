using System.Collections.Generic;
using Events;
using MiscTools;
using NUnit.Framework;
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
        [SerializeField] private Button _welcomeContinueButton;
        [SerializeField] private Button _layersButton;
        [SerializeField] private Button _cycleLipsButton;

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
            _cycleLipsButton.onClick.AddListener(HandleCycleLipsButtonClicked);
            
        }
        private void OnDisable()
        {
            _welcomeContinueButton.onClick.RemoveAllListeners();
            _layersButton.onClick.RemoveAllListeners();
            _cycleLipsButton.onClick.RemoveAllListeners();
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
        }

        private void HandleCycleLipsButtonClicked()
        {
            List<string> tags = new List<string>() { "LAYER", "LIPS" };
            _interactionEvent.TriggerEvent(tags);
            Debug.Log($"### {name}: Cycle lips button clicked. Tags: {StringTools.StringListToString(tags)}");
        }

    }
}


