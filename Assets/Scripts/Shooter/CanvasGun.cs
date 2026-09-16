using UnityEngine;

namespace Shooter
{
    public class CanvasGun : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Cookie")
            {
                Cookie c = other.GetComponent<Cookie>();
                Debug.Log("FOO");
                Destroy(other.gameObject);
            }
            
        }

    }
}

