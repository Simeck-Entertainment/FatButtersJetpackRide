using UnityEngine;

public class ColorRandomizer: MonoBehaviour
{
    [SerializeField] private Color32[] colorOptions;
    [System.NonSerialized] Renderer _rend;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rend = GetComponent<Renderer>();
        _rend.material.color = colorOptions[Random.Range(0,colorOptions.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
