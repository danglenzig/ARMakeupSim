using UnityEngine;

namespace Shooter
{
    public class Cookie : MonoBehaviour
    {

        [SerializeField] private float SPEED = 60.0f;

        private float _destroyAtY;
        private void OnEnable()
        {
            
            //_destroyAtY = m.GetDestroyAtY();
        }

        private void Start()
        {
            SceneManager m = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
            _destroyAtY = m.GetDestroyAtY();
        }

        private void OnDestroy()
        {
            Debug.Log("BAR");
        }

        private void Update()
        {
            RectTransform rt = GetComponent<RectTransform>();
            Vector3 pos = rt.position;
            pos.y -= SPEED * Time.deltaTime;
            rt.position = pos;

            

            if (rt.position.y < _destroyAtY)
            {
                NoCatchDestroy();
            }

        }

        private void NoCatchDestroy()
        {
            Debug.Log("YOU SUCK");
            Destroy(gameObject);
        }


    }
}


