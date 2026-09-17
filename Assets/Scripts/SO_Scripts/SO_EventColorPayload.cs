using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "SO_EventColorPayload", menuName = "Event Channels/Color Payload")]
    public class SO_EventColorPayload : ScriptableObject
    {
        public event System.Action<Color> OnEventTriggered;
        public void TriggerEvent(Color payload)
        {
            OnEventTriggered?.Invoke(payload);
        }
    }
}


