using UnityEngine;
using UnityEditor;

public class Morrer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifique se o objeto que tocou no Collider2D tem uma tag espec�fica
        if (other.CompareTag("Player"))
        {
#if UNITY_EDITOR
            // Saia do editor Unity (apenas durante a edi��o)
            EditorApplication.ExitPlaymode();
#endif
        }
    }
}

