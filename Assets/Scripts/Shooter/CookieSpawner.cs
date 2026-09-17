using Events;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityRandom = UnityEngine.Random;

namespace Shooter
{
    public class CookieSpawner : MonoBehaviour
    {

        [SerializeField] private SO_EventStringListPayload _interactionEvent;
        private bool _beSpawning = false;

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

            _interactionEvent.OnEventTriggered += HandleStartPressed;
        }

        private void OnDisable()
        {
            _interactionEvent.OnEventTriggered -= HandleStartPressed;
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
            t.position = new Vector3(rando, _spawnY, _spawnZ);
            newCookie.SetActive(true);
        }

        private void HandleStartPressed(List<string> tags)
        {
            if (tags[0] != "START_PRESSED") return;
            _beSpawning = true;
        }
    }


}


