using UnityEngine;
using UnityEngine.UI;
using Events;
using System.Collections.Generic;
using TMPro;

namespace Shooter
{
    public class ShooterUI : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private GameObject _startPanel;
        [SerializeField] private SO_EventStringListPayload _interactionEvent;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(HandleStartPressed);
        }
        private void OnDisable()
        {
            _startButton.onClick.RemoveAllListeners();
        }

        private void HandleStartPressed()
        {
            _startPanel.SetActive(false);
            _interactionEvent.TriggerEvent(new List<string>() { "START_PRESSED" });
        }


    }
}


