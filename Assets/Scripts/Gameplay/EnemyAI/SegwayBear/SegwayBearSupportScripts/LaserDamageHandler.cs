using System.Collections.Generic;
using UnityEngine;

public class LaserDamageHandler : MonoBehaviour
{
    [SerializeField] private float damageAmount = 15f;
    private ParticleSystem laserParticleSystem;
    private List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        laserParticleSystem = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        // Debug.Log($"[LASER HIT] Object: {other.name} | Tag: {other.tag} | Layer: {LayerMask.LayerToName(other.layer)}");
        
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
            Debug.Log($"[LASER DAMAGE] Dealing {damageAmount} damage to player!");
            player.HarmfulTouch = true;
            player.HarmfulDamageAmount = damageAmount;
            player.HarmfulTouchObjectPosition = transform.position;
        }
    }
}

