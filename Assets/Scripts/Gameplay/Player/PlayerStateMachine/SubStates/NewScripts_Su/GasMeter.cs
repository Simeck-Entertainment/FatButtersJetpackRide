using UnityEngine;

public class GasMeter : MonoBehaviour
{
    [SerializeField] Rigidbody playerRigidbody;


    public float movementThreshold = 0.1f;  // Minimum velocity to be considered "moving"
    public float idleTimeLimit = 5f;        // Time (in seconds) before declaring "No movement"

    private float idleTimer = 0f;
    private bool isMoving = true;

    void FixedUpdate()
    {
        float speed = playerRigidbody.linearVelocity.magnitude;

        if (speed >= movementThreshold)
        {
            // Player is moving
            if (!isMoving)
            {
                Debug.Log("Movement happening");
                isMoving = true;
            }

            idleTimer = 0f; // Reset timer when movement occurs
        }
        else
        {
            // Player is not moving
            idleTimer += Time.fixedDeltaTime;

            if (idleTimer >= idleTimeLimit)// && isMoving)
            {
                Debug.Log("No movement");
                playerRigidbody.GetComponent<Player>().fuel += 0.5f;
                isMoving = false;
            }
        }
    }
}
