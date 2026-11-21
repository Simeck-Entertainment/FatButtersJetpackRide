using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;
public class Key : MonoBehaviour
{
    [SerializeField] private UnityEvent onCollected;
    [Foldout("Settings"),SerializeField, Tag] private string playerTag;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {

            onCollected?.Invoke();
            gameObject.SetActive(false);
        }
    }

}
