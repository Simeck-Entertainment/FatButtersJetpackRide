using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoFuelState : PlayerLevelLoseState
{
    public PlayerNoFuelState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine){

    }

    public override void enter()
    {
        player.UI.FailReason = FailReason.NoFuel;
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
