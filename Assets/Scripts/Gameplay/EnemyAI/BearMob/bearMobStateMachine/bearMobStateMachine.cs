using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMobStateMachine : MonoBehaviour{
    public BearMobMasterState currentState;
    public void Initialize(BearMobMasterState startState){
        currentState = startState;
        currentState.enter();
}

// Update is called once per frame
    public void Update(){
        currentState.Update();
    }
    public void FixedUpdate(){
        currentState.FixedUpdate();
    }
   public void changeState(BearMobMasterState nextState){
        if(currentState != nextState){
            currentState.exit();
            currentState = nextState;
            nextState.enter();
        }
    }
}

