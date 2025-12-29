using Unity.Mathematics;
using UnityEngine;

public class PlayerWalkState : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] float walkSpeed = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
      // base speed multiplier
    public float acceleration = 5f;       // smooth speed change

    private float targetSpeed = 0f;       // speed we want to reach
    private float currentSpeed = 0f;      // current smoothed speed
    public bool hasTouchGround = false;
    public  float absZ;
    public float direction;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Untagged"))
        {
            hasTouchGround = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        hasTouchGround = false;
    }


    void Update()
    {
        WalkPlayer();
    }

    private void WalkPlayer()
    {
        if (!hasTouchGround) return;

        // Get signed Z rotation (-180 to 180)
        float rotationZ = player.transform.eulerAngles.z;
        if (rotationZ > 180f)
            rotationZ -= 360f;

       absZ = Mathf.Abs(rotationZ);

        // Determine target speed based on rotation
        if (absZ < 15f)
            targetSpeed = 0f;
        else if (absZ < 25f)
            targetSpeed = 0.5f * walkSpeed;
        else if (absZ < 35f)
            targetSpeed = 0.8f * walkSpeed;
        else
            targetSpeed = 1.2f * walkSpeed;

        // Smoothly approach the target speed
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime * acceleration);

        // Determine direction (tilt left/right)
         direction = rotationZ > 0 ? -1f : 1f;

        // Apply velocity smoothly
        player.rb.linearVelocity = new Vector3(direction * currentSpeed, player.rb.linearVelocity.y, 0f);
    }
}
