using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    private static readonly Dictionary<string, Action<object[]>> _eventDictionary = new();

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
    
    public static void StartListening(string eventName, Action listener)
    {
        if (_eventDictionary.TryGetValue(eventName, out var thisEvent))
        {
            thisEvent += args => listener();
        }
        else
        {
            thisEvent += args => listener();
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
    
    public static void StopListening(string eventName, Action listener)
    {
        if (_eventDictionary.TryGetValue(eventName, out var thisEvent))
        {
            thisEvent -= args => listener();
        }
    }
    
    public static void TriggerEvent(string eventName, params object[] args)
    {
        if (_eventDictionary.TryGetValue(eventName, out var thisEvent))
        {
            thisEvent?.Invoke(args);
        }
    }
}

