using UnityEngine;

public class InheritWalkState : PlayerAliveState
{
    int stateAge;
    bool animationSet;
    
    string[] forwardMove = { "ForeWalkSlow", "ForeWalkMid", "ForeWalkFast" };
    string[] backwardMove = { "BackWalkSlow", "BackWalkFast" };
    string[] idleAnnoyedAnims = { "idleAnnoyed1", "idleAnnoyed2" };
    
    public InheritWalkState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }

    public override void enter()
    {
        stateAge = 0;
        animationSet = true;
        // Initialize walk speed tracking
        player.walkCurrentSpeed = 0f;
        player.walkTargetSpeed = 0f;
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
        
        // Handle walk mechanics within the FSM
        CalculateWalkMovement();
        
        if (player.input.GoThrust)
        {
            player.stateMachine.changeState(player.playerThrustState);
        }
        
        PlayerWalkAnimation();
    }
    
    public override void exit()
    {
        base.exit();
    }
    
    private void CalculateWalkMovement()
    {
        if (!player.GroundTouch) 
        {
            // Reset walk values when not on ground
            player.walkTargetSpeed = 0f;
            player.walkCurrentSpeed = 0f;
            return;
        }

        // Get signed Z rotation (-180 to 180)
        float rotationZ = player.transform.eulerAngles.z;
        if (rotationZ > 180f)
            rotationZ -= 360f;

        player.walkAbsZ = Mathf.Abs(rotationZ);

        // Determine target speed based on rotation
        if (player.walkAbsZ < 15f)
            player.walkTargetSpeed = 0f;
        else if (player.walkAbsZ < 25f)
            player.walkTargetSpeed = 0.5f * player.walkSpeed;
        else if (player.walkAbsZ < 35f)
            player.walkTargetSpeed = 0.8f * player.walkSpeed;
        else
            player.walkTargetSpeed = 1.2f * player.walkSpeed;

        // Smoothly approach the target speed
        player.walkCurrentSpeed = Mathf.Lerp(player.walkCurrentSpeed, player.walkTargetSpeed, Time.fixedDeltaTime * player.walkAcceleration);

        // Determine direction (tilt left/right)
        player.walkDirection = rotationZ > 0 ? -1f : 1f;

        // Apply velocity smoothly
        player.rb.linearVelocity = new Vector3(player.walkDirection * player.walkCurrentSpeed, player.rb.linearVelocity.y, 0f);
    }
    
    private void PlayerWalkAnimation()
    {
        if (player.walkAbsZ > 15 && animationSet)
        {
            if(player.walkDirection == 1)
            {
               PlayAnim(forwardMove[Random.Range(0, 2)]); 
            }
            else
            {
                PlayAnim(backwardMove[Random.Range(0, 2)]);
            }
            
            animationSet = false;
        }
        else if (player.walkAbsZ < 15)
        {
            animationSet = true;
            player.stateMachine.changeState(player.playerIdleState);
        }
    }
}
