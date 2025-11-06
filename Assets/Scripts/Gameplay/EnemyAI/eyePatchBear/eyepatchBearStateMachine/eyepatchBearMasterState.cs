using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EyepatchBearMasterState{
    protected EyepatchBear eyepatchBear;
    protected EyepatchBearStateMachine eyepatchBearStateMachine;
    protected int durationOfState = 0;
    public EyepatchBearMasterState(EyepatchBear eyepatchBear, EyepatchBearStateMachine eyepatchBearStateMachine){
        this.eyepatchBear = eyepatchBear;
        this.eyepatchBearStateMachine = eyepatchBearStateMachine;
    }
    public virtual void enter(){
        durationOfState = 0;
    }
    public virtual void enterNoanimate(){
        durationOfState = 0;
    }
    // Start is called before the first frame update
    void Start(){
        
    }
    // Update is called once per frame
    public virtual void Update(){

    }
    public virtual void FixedUpdate(){
        durationOfState++;
    }
    public virtual void exit(){

    }
}
