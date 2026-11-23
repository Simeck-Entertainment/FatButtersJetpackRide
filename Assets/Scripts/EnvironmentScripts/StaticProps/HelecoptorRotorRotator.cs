using UnityEngine;

public class HelecoptorRotorRotator : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f,speed,0f);
    }
}
