using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "SO_EventFloatPayload", menuName = "Event Channels/Float Payload")]
    public class SO_EventFloatPayload : ScriptableObject
    {
        public event System.Action<float> OnEventTriggered;
        public void TriggerEvent(float payload)
        {
            OnEventTriggered?.Invoke(payload);
        }
    }
}


