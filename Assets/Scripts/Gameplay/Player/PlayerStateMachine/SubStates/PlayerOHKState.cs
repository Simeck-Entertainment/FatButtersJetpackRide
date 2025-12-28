using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerOHKState : PlayerLevelLoseState
{
    public PlayerOHKState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine){

    }

    public override void enter()
    {
        MonoBehaviour.Destroy(player.GetComponent<Rigidbody>());

        player.UI.FailReason = FailReason.OneHitKill;
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
