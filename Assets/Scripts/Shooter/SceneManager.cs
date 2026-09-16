using UnityEngine;

namespace Shooter
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField] private RectTransform _cookieCatcher;


        public float GetDestroyAtY()
        {
            return _cookieCatcher.position.y;
        }

    }
}


