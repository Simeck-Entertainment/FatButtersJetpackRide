using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMob : MonoBehaviour{
    [System.NonSerialized] public BearMobStateMachine stateMachine; //This gets set at start.
    public BearMobIdleState bearMobIdleState { get; set; }
    // Start is called before the first frame update
    void Start(){
       stateMachine = GetComponent<BearMobStateMachine>();
       bearMobIdleState = new BearMobIdleState(this, stateMachine);
       stateMachine.Initialize(bearMobIdleState);
    }

    // Update is called once per frame
    void Update(){
    }
    private void OnCollisionEnter(Collision other) {
    }
}




