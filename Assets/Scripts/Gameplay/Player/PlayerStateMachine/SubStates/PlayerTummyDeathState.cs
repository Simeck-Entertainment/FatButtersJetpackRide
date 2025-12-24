using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTummyDeathState : PlayerLevelLoseState
{
    public PlayerTummyDeathState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine){

    }

    public override void enter(){
        player.UI.FailReason = FailReason.NoHealth;
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
