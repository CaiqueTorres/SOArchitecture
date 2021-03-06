﻿using System.Collections.Generic;
using SOArchitecture.Runtime.GameEvents.Interfaces;
using UnityEngine;

namespace SOArchitecture.Runtime.GameEvents.Scripts
{
    public abstract class GameEventBase : ScriptableObject, IGameEvent
    {
        private readonly List<IGameEventListener> _listeners = new List<IGameEventListener>();

#if UNITY_EDITOR
#pragma warning disable 649
        [TextArea(3, 10), SerializeField] private string description;
#pragma warning disable 649
#endif

        public void Raise()
        {
            for (var i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised();
            }
        }

        public void Register(IGameEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void Unregister(IGameEventListener listener)
        {
            _listeners.Remove(listener);
        }
    }

    public abstract class GameEventBase<T> : ScriptableObject, IGameEvent<T>
    {
        public T value;
#if UNITY_EDITOR
        public T simulateValue;
#endif
        private readonly List<IGameEventListener<T>> _listeners = new List<IGameEventListener<T>>();

#if UNITY_EDITOR
        [TextArea(3, 10), SerializeField] private string description;
#endif

        public virtual void Raise(T value)
        {
            this.value = value;
            for (var i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised(value);
            }
        }

        public void Register(IGameEventListener<T> listener)
        {
            _listeners.Add(listener);
        }

        public void Unregister(IGameEventListener<T> listener)
        {
            _listeners.Remove(listener);
        }
    }
}
