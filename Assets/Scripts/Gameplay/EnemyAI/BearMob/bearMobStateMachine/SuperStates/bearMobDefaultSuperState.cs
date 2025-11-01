using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMobSuperState : BearMobMasterState{
    public BearMobSuperState(BearMob bearMob, BearMobStateMachine bearMobStateMachine) : base(bearMob, bearMobStateMachine){
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
