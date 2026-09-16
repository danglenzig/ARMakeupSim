using UnityEngine;
using UnityRandom = UnityEngine.Random;

namespace Shooter
{
    public class CookieSpawner : MonoBehaviour
    {

        private bool _beSpawning = true;

        [SerializeField] private RectTransform _maxLeft;
        [SerializeField] private RectTransform _maxRight;
        [SerializeField] private GameObject _cookiePrefab;

        private float _ta = 0.0f;
        private float _spawnInterval = 1.5f;

        private float _spawnY;
        private float _spawnZ;

        private void OnEnable()
        {
            RectTransform t = GetComponent<RectTransform>();
            _spawnY = t.position.y;
            _spawnZ = t.position.z;
        }

        private void Update()
        {
            if (!_beSpawning) return;
            _ta += Time.deltaTime;
            if (_ta < _spawnInterval) return;
            _ta = 0.0f;

            SpawnCookie();

        }

        private void SpawnCookie()
        {
            

            float rando = Random.Range(_maxLeft.position.x, _maxRight.position.x);

            GameObject newCookie = Instantiate(_cookiePrefab, gameObject.GetComponent<RectTransform>(), false);
            RectTransform t = newCookie.GetComponent<RectTransform>();
            //t.anchoredPosition = Vector2.zero;
            t.position = new Vector3(rando, _spawnY, _spawnZ);
            newCookie.SetActive(true);



        }

    }


}


