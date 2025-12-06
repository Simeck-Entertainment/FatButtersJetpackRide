using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace AshGames.Channels
{
    public abstract class TypedReceiver<T, S> : MonoBehaviour where T : TypedChannel<S>
    {
        [SerializeField] T channel;
        [SerializeField] bool requireValue;
        [SerializeField, ShowIf(nameof(requireValue))] S value;

        [SerializeField] UnityEvent<S> onReceived;

        void OnEnable() =>
            channel.AddListener(Check);

        void OnDisable() =>
            channel.RemoveListener(Check);

        void Check(S newValue)
        {
            if (!requireValue || Equals(value, newValue))
                onReceived.Invoke(newValue);
        }
    }
}