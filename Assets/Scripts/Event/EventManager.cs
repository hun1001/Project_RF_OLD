using System;
using System.Collections;
using System.Collections.Generic;

namespace EventManager
{
    public static class EventManager
    {
        private static Dictionary<string, Action<object[]>> _eventDictionary = new();
        
        public static void StartListening(string eventName, Action<object[]> listener)
        {
            if (_eventDictionary.TryGetValue(eventName, out var thisEvent))
            {
                thisEvent += listener;
            }
            else
            {
                thisEvent += listener;
                _eventDictionary.Add(eventName, thisEvent);
            }
        }
        
        public static void StopListening(string eventName, Action<object[]> listener)
        {
            if (_eventDictionary.TryGetValue(eventName, out var thisEvent))
            {
                thisEvent -= listener;
            }
        }
        
        public static void TriggerEvent(string eventName, params object[] args)
        {
            if (_eventDictionary.TryGetValue(eventName, out var thisEvent))
            {
                thisEvent.Invoke(args);
            }
        }
    }
}
