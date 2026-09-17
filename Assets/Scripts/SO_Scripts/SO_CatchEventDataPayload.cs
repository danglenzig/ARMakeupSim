using UnityEngine;

namespace Events
{
    public struct CatchEventData
    {
        public string EventMode;
        public Color EventColor;

        public CatchEventData(string mode, Color color)
        {
            EventMode = mode;
            EventColor = color;
        }
    }

    [CreateAssetMenu(fileName = "SO_CatchEventDataPayload", menuName = "Event Channels/Catch Event Data Payload")]
    public class SO_CatchEventDataPayload : ScriptableObject
    {
        public event System.Action<CatchEventData> OnEventTriggered;
        public void TriggerEvent(CatchEventData payload)
        {
            OnEventTriggered?.Invoke(payload);
        }
    }
}


