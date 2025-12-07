using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Events;
using System.Collections.Generic;

namespace AshGames.Channels
{
    [CreateAssetMenu(menuName = "Channels/Void")]
    public class VoidChannel : ScriptableObject
    {
        [SerializeField] UnityEvent onSent;
        [SerializeField] bool debug;

        [Button, ContextMenu("Send")]
        public void Send()
        {
#if UNITY_EDITOR
            invocations.Add(Time.time);
#endif
            onSent.Invoke();

            if (debug) Debug.Log(name + " Sent!");
        }

        public void AddListener(UnityAction action) =>
            onSent.AddListener(action);

        public void RemoveListener(UnityAction action) =>
            onSent.RemoveListener(action);

#if UNITY_EDITOR
        [HorizontalLine]

        [SerializeField, ReadOnly] List<float> invocations = new();

        void OnEnable() => invocations.Clear();
#endif
    }
}
