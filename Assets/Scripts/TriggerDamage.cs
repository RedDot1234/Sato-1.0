using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public HeartSystem heart; // A reference to the HeartSystem class or component.
    public PlayerLogic player; // A reference to the PlayerLogic class or component.
    
    
    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.tag == "Player")
        {
            heart.vida--; // Decrease the 'vida' property of the HeartSystem class (assuming 'vida' represents the player's life/health).
            player.animator.SetTrigger("TakeDamage");
           
        }

    }
}