using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma: MonoBehaviour
{

    private int vidaAtual = 100;
    public Transform healthBar;
    public GameObject healthBarObject;

    private Vector3 healthBarScale;
    private float healthPercent;

    private void Start()
    {
        healthBarScale = healthBar.localScale;
        healthPercent = healthBarScale.x / vidaAtual;
    }

    private void UpdateHealthbar()
    {
        healthBarScale.x = healthPercent * vidaAtual;
        healthBar.localScale = healthBarScale;

    }
    public void DanoNoInimigo(int dano)
    {
        vidaAtual -= dano;
        UpdateHealthbar();
        if (vidaAtual <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
