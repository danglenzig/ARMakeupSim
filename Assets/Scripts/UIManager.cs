using Events;
using UnityEngine;
using UnityEngine.UI;

namespace MakupSim
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private SO_EventStringListPayload _interactionEvent;
        [SerializeField] private GameObject _welcomeUI;
        [SerializeField] private GameObject _inGameUI;
        [SerializeField] private Button _welcomeContinueButton;

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

            _welcomeContinueButton.onClick.AddListener(HandleWelcomeContinueButtonClicked);
            
        }
        private void OnDisable()
        {
            _welcomeContinueButton.onClick.RemoveAllListeners();
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

    }
}


