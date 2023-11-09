using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataquePlayer : MonoBehaviour
{
    private bool atacando;
    private float tempoEntreAtaques = 1.0f; // Tempo de espera em segundos
    private float tempoPassadoDesdeAtaque = 0.0f;
    public Animator animator;
    public Transform ataquePoint;
    public float ataqueRanger = 1f;
    public LayerMask enemyLayers;

    void Update()
    {
        if (tempoPassadoDesdeAtaque < tempoEntreAtaques)
        {
            tempoPassadoDesdeAtaque += Time.deltaTime;
        }

        atacando = Input.GetButtonDown("Fire1");

        if (atacando && tempoPassadoDesdeAtaque >= tempoEntreAtaques)
        {
            Ataque();
            tempoPassadoDesdeAtaque = 1f; // Reinicia o tempo de espera
        }
    }

    void Ataque()
    {
        animator.SetTrigger("ataque");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(ataquePoint.position, ataqueRanger, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<morteInimigo>().DanoNoInimigo(100);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(ataquePoint.position, ataqueRanger);
    }
}
