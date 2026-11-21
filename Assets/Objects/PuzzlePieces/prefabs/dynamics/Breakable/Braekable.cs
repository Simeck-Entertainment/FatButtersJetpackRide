using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Events;


public class Braekable : MonoBehaviour
{
    [SerializeField] private UnityEvent onBreak;

    [SerializeField] private LayerMask allowedLayers;

    void OnTriggerEnter(Collider other)
    {
        if ((allowedLayers.value & (1 << other.gameObject.layer)) > 0)
        {
            Break();
        }
    }

    [Button]
    public void Break()
    {

        onBreak?.Invoke();
        print("Break");
    }
}
