using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "SO_EventStringListPayload", menuName = "Event Channels/String List Payload")]
    public class SO_EventStringListPayload : ScriptableObject
    {
        public event System.Action<List<string>> OnEventTriggered;
        public void TriggerEvent(List<string> payload)
        {
            OnEventTriggered?.Invoke(payload);
        }
    }
}


