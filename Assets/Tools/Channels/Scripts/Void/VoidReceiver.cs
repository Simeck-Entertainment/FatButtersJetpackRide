using UnityEngine;
using UnityEngine.Events;

namespace AshGames.Channels
{
    public class VoidReceiver : MonoBehaviour
    {
        [SerializeField] VoidChannel channel;
        [SerializeField] UnityEvent onReceived;

        void OnEnable() =>
            channel.AddListener(onReceived.Invoke);

        void OnDisable() =>
            channel.RemoveListener(onReceived.Invoke);
    }
}