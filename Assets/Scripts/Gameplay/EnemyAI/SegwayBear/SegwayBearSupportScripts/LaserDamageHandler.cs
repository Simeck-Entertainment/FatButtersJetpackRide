using UnityEngine;

/// <summary>
/// Handles laser particle collision damage for SegwayBear.
/// Attach this to a ParticleSystem with Collision enabled and "Send Collision Messages" checked.
/// Works with non-trigger colliders since OnParticleCollision doesn't work with triggers.
/// </summary>
public class LaserDamageHandler : MonoBehaviour
{
    [Header("Damage Settings")]
    [SerializeField] private float damageAmount = 2.0f;
    [SerializeField] private float damageCooldown = 1.0f;
    
    private float lastDamageTime = -999f;

    void OnParticleCollision(GameObject other)
    {
        Player player = FindPlayer(other);
        
        if (player != null && CanApplyDamage())
        {
            ApplyDamage(player);
        }
    }

    private Player FindPlayer(GameObject hitObject)
    {
        // Try to find Player component in parent hierarchy
        Player player = hitObject.GetComponentInParent<Player>();
        
        // Fallback: check for PlayerCollisionReporter
        if (player == null)
        {
            PlayerCollisionReporter reporter = hitObject.GetComponent<PlayerCollisionReporter>();
            if (reporter != null)
            {
                player = reporter.player;
            }
        }
        
        return player;
    }

    private bool CanApplyDamage()
    {
        return Time.time - lastDamageTime >= damageCooldown;
    }

    private void ApplyDamage(Player player)
    {
        lastDamageTime = Time.time;
        
        player.HarmfulTouch = true;
        player.HarmfulDamageAmount = damageAmount;
        player.HarmfulTouchObjectPosition = transform.position;
    }
}
