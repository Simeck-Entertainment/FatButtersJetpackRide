using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyepatchBearStateMachine : MonoBehaviour{
    public EyepatchBearMasterState currentState;
    public void Initialize(EyepatchBearMasterState startState){
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
   public void changeState(EyepatchBearMasterState nextState){
        if(currentState != nextState){
            currentState.exit();
            currentState = nextState;
            nextState.enter();
        }
    }
}

