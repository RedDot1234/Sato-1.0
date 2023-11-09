using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public Image profile;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;
    private bool isTyping; // Indica se o texto est� sendo digitado

    public void Speech(Sprite p, string[] txt, string actorName)
    {
        dialogueObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        actorNameText.text = actorName;
        index = 0;
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        isTyping = true; // Inicia a digita��o
        speechText.text = ""; // Limpa o texto

        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false; // Conclui a digita��o
    }

    public void NextSentence()
    {
        // Verifica se a digita��o est� em andamento; n�o faz nada se estiver
        if (isTyping)
        {
            return;
        }

        if (index < sentences.Length - 1)
        {
            index++;
            StartCoroutine(TypeSentence());

        }
        else
        {
            EndDialogue();

        }
    }

    void EndDialogue()
    {
        dialogueObj.SetActive(false);
        index = 0;
    }
}