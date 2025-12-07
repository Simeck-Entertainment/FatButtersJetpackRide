using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

namespace AshGames.Channels
{
    public abstract class TypedChannel<T> : ScriptableObject
    {
        [SerializeField] UnityEvent<T> onSent;

        public void Send(T value)
        {
#if UNITY_EDITOR
            invocations.Add(new(Time.time, value));
#endif
            onSent.Invoke(value);
        }

        public void AddListener(UnityAction<T> action) =>
            onSent.AddListener(action);

        public void RemoveListener(UnityAction<T> action) =>
            onSent.RemoveListener(action);

#if UNITY_EDITOR
        [HorizontalLine]

        [SerializeField, ReadOnly] List<Invocation<T>> invocations = new();

        [SerializeField] T testValue;

        [Button]
        void SendTestValue() => Send(testValue);

        void OnEnable() => invocations.Clear();

        [System.Serializable]
        struct Invocation<S>
        {
            [SerializeField] float time;
            [SerializeField] S value;

            public Invocation(float time, S value)
            {
                this.time = time;
                this.value = value;
            }
        }
#endif
    }
}