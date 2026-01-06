using UnityEngine;

public class GasMeter : MonoBehaviour
{
    [SerializeField] Rigidbody playerRigidbody;
    [SerializeField] CorgiEffectHolder corgiEffectHolder;
    public float movementThreshold = 0.1f;  // Minimum velocity to be considered "moving"
    public float idleTimeLimit = 5f;        // Time (in seconds) before declaring "No movement"

    private float idleTimer = 0f;
    private bool isMoving = true;
    [SerializeField] AudioSource growlAudioSource;
    [SerializeField] AudioClip growlAudioClip;

    Player player;
    InputDriver inputDriver;

    void Start()
    {
        // player = playerRigidbody.GetComponent<Player>();
        // inputDriver = player.input;

        player = GetComponent<Player>();
        inputDriver = GetComponent<InputDriver>();
    }

    public void PlayerBoost() {
        // Mobile: Two fingers = boost
        // PC/Gamepad: Any thrust input + M key = boost
        bool isMultiTouchBoost = inputDriver.touchCount > 1;
        bool isKeyboardBoost = inputDriver.GoThrust && Input.GetKey(KeyCode.M);
        bool isBoostActive = isMultiTouchBoost || isKeyboardBoost;
        
        if (isBoostActive && player.fuel > 0f) {
            float previousFuel = player.fuel;
            player.thrust = player.baseThrust + 12.5f;            
            player.fuel -= 1f;
            
            string triggerType = isMultiTouchBoost ? "Multi-Touch" : "Keyboard/Gamepad (Thrust+M)";
            Debug.Log($"PlayerBoost ACTIVE [{triggerType}] - Thrust: {player.thrust} (base: {player.baseThrust}), Fuel: {previousFuel} -> {player.fuel} (wasted: 1.0), TouchCount: {inputDriver.touchCount}");
        } else {
            // Reset thrust to base when boost conditions are not met
            player.thrust = player.baseThrust;
        }
    }

    void FixedUpdate()
    {
        PlayerBoost();
        
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
                if (isMoving)
                {
                    growlAudioSource.clip = growlAudioClip;
                    growlAudioSource.Play();
                    corgiEffectHolder.StartMinusRotParticles();
                    corgiEffectHolder.StartPlusRotParticles();
                    isMoving = false;
                }

            }
        }
    }
}
