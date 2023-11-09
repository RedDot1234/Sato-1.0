using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneLoader : MonoBehaviour
{
    [Header("Porcentagem")]
    public Slider sLoading;
    public Text txtPorcentagem;

    [Header("Imagem")]
    public Image imgParaMudar;
    public Sprite[] imagens;

    private void Start()
    {
        sLoading.value = 0;
        txtPorcentagem.text = "0%";
        StartCoroutine(LoadScene_Estiloso());
    }

    public void MudarImagem()
    {
        int rand = Random.Range(0, imagens.Length);

        imgParaMudar.sprite = imagens[rand];

    }

    public void Update()
    {
     if (Input.GetKeyDown(KeyCode.A))
        {
            MudarImagem();  
        }
    }

    private IEnumerator LoadScene_Estiloso()
    {
        yield return null;

        AsyncOperation operation = SceneManager.LoadSceneAsync(3);
        operation.allowSceneActivation = false;

        float progresso = 0.0f;

        while (progresso < 100)
        {
            yield return new WaitForSeconds(0.8f);

            progresso += Random.Range(5.0f, 15.0f);
            sLoading.value = progresso;
            txtPorcentagem.text = ((int)progresso) + "%";

        }

        sLoading.value = 100;
        txtPorcentagem.text = "100%";
        operation.allowSceneActivation = true;

        yield return null;
    }
}
