using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 3f;  // Velocidade do inimigo
    public float patrolDistance = 5f;  // Dist�ncia m�xima para patrulhar
    private bool movingRight = true;  // Inicialmente, o inimigo se move para a direita

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;  // Salvar a posi��o inicial
    }

    void Update()
    {
        // Mova o inimigo
        if (movingRight)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        // Verifique se o inimigo alcan�ou a dist�ncia m�xima
        if (Vector3.Distance(initialPosition, transform.position) >= patrolDistance)
        {
            // Inverta a dire��o
            movingRight = !movingRight;

            // Inverta a escala (para inverter a dire��o visualmente)
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }
}