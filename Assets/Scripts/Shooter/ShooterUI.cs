using UnityEngine;
using UnityEngine.UI;
using Events;
using TMPro;

namespace Shooter
{
    public class ShooterUI : MonoBehaviour
    {
        private const float ALL_THE_WAY = 1080.0f;

        //[SerializeField] private SO_EventFloatPayload _chinUpdateEvent;
        //[SerializeField] private TMP_Text _debugText;
        //[SerializeField] private RectTransform _canvasGun;
        [SerializeField] private SO_EventFloatPayload _fuckYouEvent;
        [SerializeField] private TMP_Text _fuckYouText;
        private void OnEnable()
        {

            _fuckYouEvent.OnEventTriggered += HandleFuckYouEvent;

            //_chinUpdateEvent.OnEventTriggered += HandleChinUpdate;
        }
        private void OnDisable()
        {
            _fuckYouEvent.OnEventTriggered -= HandleFuckYouEvent;
            //_chinUpdateEvent.OnEventTriggered -= HandleChinUpdate;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        private void HandleFuckYouEvent(float val)
        {
            _fuckYouText.text = val.ToString();
        }

        /*
        private void HandleChinUpdate(float value)
        {
            debugText.text = value.ToString();
            _canvasGun.position = new Vector3(ALL_THE_WAY * value, _canvasGun.position.y, _canvasGun.position.z);
        }
        */
    }
}


