using System.Collections.Generic;
using UnityEngine;

public class LaserDamageHandler : MonoBehaviour
{
    [SerializeField] private float damageAmount = 2.0f;
    [SerializeField] private float damageCooldown = 1.0f; // Seconds between damage
    
    private ParticleSystem laserParticleSystem;
    private List<ParticleCollisionEvent> collisionEvents;
    private float lastDamageTime = -999f;

    void Start()
    {
        laserParticleSystem = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        // Check if we hit something with a Player component or PlayerCollisionReporter
        Player player = other.GetComponentInParent<Player>();
        if (player == null)
        {
            PlayerCollisionReporter reporter = other.GetComponent<PlayerCollisionReporter>();
            if (reporter != null)
            {
                player = reporter.player;
            }
        }

        if (player != null)
        {
            // Check cooldown to prevent multiple damage from same laser burst
            if (Time.time - lastDamageTime < damageCooldown)
            {
                return; // Still on cooldown, skip damage
            }
            
            lastDamageTime = Time.time;
            Debug.Log($"[LASER DAMAGE] Dealing {damageAmount} damage to player!");
            player.HarmfulTouch = true;
            player.HarmfulDamageAmount = damageAmount;
            player.HarmfulTouchObjectPosition = transform.position;
        }
    }
}

