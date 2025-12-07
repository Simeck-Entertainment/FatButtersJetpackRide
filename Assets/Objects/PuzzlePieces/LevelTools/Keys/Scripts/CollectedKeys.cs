using UnityEngine;
using System.Collections.Generic;

public class CollectedKeys : MonoBehaviour
{
    [SerializeField] CollectibleData collectibleData;
    public void AddKey(int key)
    {
        collectibleData.Keys += key;
    }
}
