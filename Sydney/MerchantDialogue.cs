using UnityEngine;
using UnityEngine.UI;

public class MerchantDialogue : MonoBehaviour
{
    public string[] dialogueLines; // Array to hold dialogue lines
    public GameObject dialoguePanel; // UI Panel to display dialogue
    public Text dialogueText; // UI Text to display the dialogue

    private int currentLineIndex = 0;
    private bool isPlayerInRange = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (dialoguePanel.activeInHierarchy)
            {
                DisplayNextLine();
            }
            else
            {
                dialoguePanel.SetActive(true);
                dialogueText.text = dialogueLines[currentLineIndex];
            }
        }
    }

    void DisplayNextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
            currentLineIndex = 0; // Reset the dialogue
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialoguePanel.SetActive(false);
            currentLineIndex = 0; // Reset the dialogue
        }
    }
}
