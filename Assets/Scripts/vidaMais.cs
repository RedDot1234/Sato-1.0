using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaMais : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HeartSystem playerHealth = other.GetComponent<HeartSystem>();

            if (playerHealth != null)
            {
                // Regenere a vida do jogador (adicione 1 à vida atual)
                playerHealth.vida++;

                // Destrua o objeto de vida
                Destroy(gameObject);
            }
        }
    }
}
