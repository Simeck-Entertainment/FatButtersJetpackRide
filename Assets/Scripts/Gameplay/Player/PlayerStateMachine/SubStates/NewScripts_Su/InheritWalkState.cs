using UnityEngine;

public class InheritWalkState : PlayerAliveState
{
    int stateAge;
    public InheritWalkState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }


    string[] forwardMove = { "ForeWalkSlow", "ForeWalkMid", "ForeWalkFast" };
    string[] backwardMove = { "BackWalkSlow", "BackWalkFast" };
    string[] idleAnnoyedAnims = { "idleAnnoyed1", "idleAnnoyed2" };
    bool animationSet;
    PlayerWalkState playerWalkState;
    public override void enter()
    {
        playerWalkState = player.GetComponent<PlayerWalkState>();
        stateAge = 0;
        if (player.animationPercentage == 0.0f)
        { //It should only ever be 0.0 on start.
          //   PlayAnim(forwardMove[Random.Range(0, 2)]);
        }
        //DeActivateGravyBoat();
        base.enter();
    }

    public override void Update()
    {
        base.Update();
    }
    public override void FixedUpdate()
    {
        stateAge++;
        base.FixedUpdate();
        if (player.input.GoThrust)
        {
            player.stateMachine.changeState(player.playerThrustState);
        }
        // if (GetNormalizedTime() >= 0.99f)
        // {
        //     PlayAnim(backwardMove[Random.Range(0, 2)]);
        // }
        PlayerWalkAnimation();

        // if (stateAge > 0 & stateAge % 1200 == 0)
        // {
        //    // PlayAnim(idleAnnoyedAnims[Random.Range(0, 2)]);

        //    PlayAnim(idleAnnoyedAnims[Random.Range(0, 2)]);
        // }


    }
    public override void exit()
    {
        base.exit();
    }
    public void PlayerWalkAnimation()
    {
        if (playerWalkState.absZ > 15 && animationSet)
        {
            //Debug.Log();
            if(playerWalkState.direction == 1)
            {
               PlayAnim(forwardMove[Random.Range(0, 2)]); 
            }
            else
            {
                PlayAnim(backwardMove[Random.Range(0, 2)]);
            }
            
            animationSet = false;
            
        }
        else if (playerWalkState.absZ < 15)
        {
            animationSet = true;
             player.stateMachine.changeState(player.playerIdleState);
        }
    }

}
