using UnityEngine;

namespace Shooter
{
    public class Cookie : MonoBehaviour
    {

        private void OnDestroy()
        {
            Debug.Log("BAR");
        }
    }
}


