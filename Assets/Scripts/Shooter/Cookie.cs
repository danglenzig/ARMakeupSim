using Events;
using UnityEngine;
using UnityEngine.UI;
using MiscTools;
using UnityRandom = UnityEngine.Random;
using System.Collections.Generic;

namespace Shooter
{
    public class Cookie : MonoBehaviour
    {
        private const string LIPS = "LIPS";
        private const string EYES = "EYES";
        private const float SPEED_TWEAK = 40.0f;

        [SerializeField] private Texture2D _lipsTexture;
        [SerializeField] private Texture2D _eyesTexture;

        [SerializeField] private SO_CatchEventDataPayload _catchEvent;

        

        [SerializeField] private float SPEED = 60.0f;
        [SerializeField] private SO_EventColorPayload _changeColorEvent;

        private RawImage _image;

        public bool IsCaught = false;

        private float _destroyAtY;

        private float _actualSpeed;

        private string _mode = LIPS;

        private void Awake()
        {
            _image = GetComponent<RawImage>();
            
            _actualSpeed = SPEED + UnityRandom.Range(-SPEED_TWEAK, SPEED_TWEAK);

        }

        private void OnEnable()
        {

            int randoInt = UnityRandom.Range(0, 10);
            if (randoInt %2 == 0)
            {
                _mode = LIPS;
            }
            else
            {
                _mode = EYES;
            }

            switch (_mode)
            {
                case LIPS:
                    _image.texture = _lipsTexture;
                    break;
                case EYES:
                    _image.texture = _eyesTexture;
                    break;
                default:
                    _image.texture = null;
                    break;
            }


            //_destroyAtY = m.GetDestroyAtY();
        }

        private void Start()
        {
            _image.color = ColorTools.GetRandomColor();

            SceneManager m = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
            _destroyAtY = m.GetDestroyAtY();
        }

        private void OnDestroy()
        {
            /*
            if (IsCaught)
            {
                Color myColor = _image.color;
                _changeColorEvent.TriggerEvent(myColor);
                Debug.Log("FOO");
            }
            */

            //Debug.Log("BAR");
        }

        private void Update()
        {
            RectTransform rt = GetComponent<RectTransform>();
            Vector3 pos = rt.position;
            pos.y -= _actualSpeed * Time.deltaTime;
            rt.position = pos;

            

            if (rt.position.y < _destroyAtY)
            {
                NoCatchDestroy();
            }

        }

        private void NoCatchDestroy()
        {
            Debug.Log("YOU SUCK");
            DieGracefully();
        }

        public void DieGracefully()
        {
            if (IsCaught)
            {
                Color myColor = _image.color;
                //_changeColorEvent.TriggerEvent(myColor);
                CatchEventData data = new CatchEventData(_mode, myColor);
                _catchEvent.TriggerEvent(data);
            }
            Destroy(gameObject);
        }


    }
}


