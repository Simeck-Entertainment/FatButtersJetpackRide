using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyepatchBearIdleState : EyepatchBearSuperState{
    public EyepatchBearIdleState(EyepatchBear eyepatchBear, EyepatchBearStateMachine eyepatchBearStateMachine) : base(eyepatchBear, eyepatchBearStateMachine){
    }

    public override void enter(){
        base.enter();
    }
    public override void Update(){
        base.Update();
    }

    public override void FixedUpdate(){
        base.FixedUpdate();
    }
}
