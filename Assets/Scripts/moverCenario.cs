using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverCenario : MonoBehaviour
{
    public float speed = 3f;  // Velocidade do elevador
    public float verticalDistance = 5f;  // Dist�ncia m�xima para subir e descer
    private bool movingUp = true;  // Inicialmente, o elevador se move para cima

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;  // Salvar a posi��o inicial
    }

    void Update()
    {
        // Mova o elevador
        if (movingUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        // Verifique se o elevador alcan�ou a dist�ncia m�xima
        if (Vector3.Distance(initialPosition, transform.position) >= verticalDistance)
        {
            // Inverta a dire��o
            movingUp = !movingUp;
        }
    }
}
