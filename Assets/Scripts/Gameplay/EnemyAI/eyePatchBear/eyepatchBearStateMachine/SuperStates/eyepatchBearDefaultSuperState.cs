using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyepatchBearSuperState : EyepatchBearMasterState{
    public EyepatchBearSuperState(EyepatchBear eyepatchBear, EyepatchBearStateMachine eyepatchBearStateMachine) : base(eyepatchBear, eyepatchBearStateMachine){
    }


    public override void enter(){
        base.enter();
    }

    public override void Update(){
        base.Update();
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
