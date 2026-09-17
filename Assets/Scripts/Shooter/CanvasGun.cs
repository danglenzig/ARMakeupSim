using Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter
{
    [RequireComponent(typeof(RectTransform))]

    public class CanvasGun : MonoBehaviour
    {
        private const float ALL_THE_WAY = 1080.0f;
        [SerializeField] private SO_EventFloatPayload _chinUpdateEvent;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private float _lerpFactor = 0.8f;

        [SerializeField] private TMP_Text _debugText;
        [SerializeField] private bool _debugMode = false;

        //[SerializeField] private SO_EventColorPayload _changeColorEvent;

        [SerializeField] private SO_CatchEventDataPayload _catchEvent;

        private int _collected = 0;

        private RectTransform _transform;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
        }

        private void Start()
        {
            _scoreText.text = _collected.ToString();
        }

        private void OnEnable()
        {
            _chinUpdateEvent.OnEventTriggered += HandleChinUpdate;
            //_changeColorEvent.OnEventTriggered += HandleChangeColor;
        }
        private void OnDisable()
        {
            _chinUpdateEvent.OnEventTriggered -= HandleChinUpdate;
            //_changeColorEvent.OnEventTriggered -= HandleChangeColor;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Cookie")
            {
                Cookie c = other.GetComponent<Cookie>();
                c.IsCaught = true;


                //Destroy(other.gameObject);
                c.DieGracefully();


                _collected++;
                _scoreText.text = _collected.ToString();
            }
            
        }

        private void HandleChinUpdate(float value)
        {
            if (_debugMode) return;

            _debugText.text = value.ToString();
            Vector3 targetPos = new Vector3(ALL_THE_WAY * value, _transform.position.y, _transform.position.z);
            Vector3 newPos  = Vector3.Lerp(_transform.position, targetPos, _lerpFactor);
            _transform.position = newPos;
            //_transform.position = new Vector3(ALL_THE_WAY * value, _transform.position.y, _transform.position.z);
        }

        private void HandleChangeColor(Color c)
        {
            //GetComponent<RawImage>().color = c;
        }

        private void HandleCatchEvent(CatchEventData data)
        {
            //
        }
    }
}

