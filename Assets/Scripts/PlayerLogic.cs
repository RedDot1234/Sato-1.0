using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    public float velocidade = 5.0f; // Ajuste a velocidade conforme necessário
    private bool viradoParaDireita = true;
    public Rigidbody2D rb;
    public Animator animator;
    private bool isPaused;




    [Header("Paineis e Menu")]
    public GameObject pausePainel;
    public string cena;
    internal object anim;

    private void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {

        if (!isPaused)
        {

        

            if(Input.GetAxis("Horizontal") != 0)
            {

                animator.SetBool("taCorrendo", true);

            }
            else
            {
                animator.SetBool("taCorrendo", false);
            
            }

        

                float movimentoHorizontal = Input.GetAxis("Horizontal");

            // Verifique a direção do movimento e ajuste a escala do objeto
            if (movimentoHorizontal > 0 && !viradoParaDireita)
            {
                Flip();
           
            }
            else if (movimentoHorizontal < 0 && viradoParaDireita)
            {
                Flip();
            }

            // Aplica o movimento
            Vector3 movimento = new Vector3(movimentoHorizontal, 0, 0);
            transform.Translate(movimento * velocidade * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            PausarScreen();
        }           
    }
    void PausarScreen()
    {
        if (isPaused) 
        {
            isPaused = false;
            Time.timeScale = 1f;
            pausePainel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            pausePainel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }

    private void Flip()
    {
        viradoParaDireita = !viradoParaDireita;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

}