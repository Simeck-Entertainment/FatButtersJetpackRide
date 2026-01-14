using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{

   
     
   
  [Header("Bat Settings")]
    [SerializeField] GameObject batPrefab;
    [SerializeField] int maxBats = 5;
    [SerializeField] float spawnCooldown = 1.5f;
    [SerializeField] float batSpeed = 4f;

    [Header("Path")]
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform[] flightPath;
    [SerializeField]public Transform UpperOffset;
    [SerializeField]public Transform LowerOffset;

    private bool activated;
    private float spawnTimer;
    private int spawnedCount;

    #region  Fields
    [HideInInspector]public Transform[] FlightPath;
    [HideInInspector] public int spawnLength;
     [HideInInspector] public int spawnAmount;
    [HideInInspector] public int BatSpeed;
    #endregion

    void Update()
    {
        if (!activated) return;

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0 && spawnedCount < maxBats)
        {
            SpawnBat();
            spawnTimer = spawnCooldown;
        }
    }

    void SpawnBat()
    {
        float offset = Random.Range(
            LowerOffset.localPosition.y,
            UpperOffset.localPosition.y
        );

        Vector3 spawnPos = spawnPoint.position + Vector3.up * offset;
        GameObject bat = Instantiate(batPrefab, spawnPos, Quaternion.identity);

        BatRunner runner = bat.GetComponent<BatRunner>();
        runner.speed = batSpeed;
        runner.path = BuildPath(offset);
        bat.SetActive(true);
        spawnedCount++;
    }

    List<Vector3> BuildPath(float offset)
    {
        List<Vector3> path = new List<Vector3>();

        foreach (Transform p in flightPath)
        {
            path.Add(p.position + Vector3.up * offset);
        }

        return path;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activated = true;
        }
    }
   
   
  
}


