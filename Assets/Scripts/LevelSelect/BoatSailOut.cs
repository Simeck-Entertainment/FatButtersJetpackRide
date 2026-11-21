using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSailOut : MonoBehaviour
{
    [SerializeField] CollectibleData data;
    [SerializeField] Vector3 OgPos;
    [SerializeField] Vector3 SailedPos;
    [SerializeField] int TriggerWhenLevelBeaten;
    float sailTimeCounter;
    [SerializeField, Tooltip("Measured in seconds")] float sailTimeThreshold;
    bool doISail;
    // Start is called before the first frame update
    void Start()
    {
        //The only time the boat sails is when it is appropriate to.
        sailTimeCounter = 0;
        doISail = false;
        if(data.LevelBeaten[TriggerWhenLevelBeaten] & !data.LevelBeaten[TriggerWhenLevelBeaten+1]){
            doISail = true;
        }

        if(data.LevelBeaten[TriggerWhenLevelBeaten+1]){
            transform.position = SailedPos;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(doISail & sailTimeCounter < sailTimeThreshold){
            sailTimeCounter += Time.deltaTime;
            transform.position = Vector3.Lerp(OgPos,SailedPos,Helper.RemapToBetweenZeroAndOne(0,sailTimeThreshold,sailTimeCounter));
        }
    }
}
