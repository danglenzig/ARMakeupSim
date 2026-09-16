using UnityEngine;
using TMPro;

namespace Shooter
{
    public class CanvasGun : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        private int _collected = 0;

        private void Start()
        {
            _scoreText.text = _collected.ToString();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Cookie")
            {
                Cookie c = other.GetComponent<Cookie>();
                Destroy(other.gameObject);
                _collected++;
                _scoreText.text = _collected.ToString();
            }
            
        }

    }
}

