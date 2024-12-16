using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue Settings")]
    public TextMeshProUGUI dialogueText; // Reference to the dialogue box UI
    public List<string> dialogueLines; // List of dialogue strings
    public float typingSpeed = 0.05f;  // Speed of text appearing character-by-character

    private int currentLineIndex = 0; // Tracks the current dialogue line
    private bool isTyping = false;   // Checks if text is still typing
    private Coroutine typingCoroutine;

    void Start()
    {
        if (dialogueLines.Count > 0)
        {
            StartDialogue();
        }
        else
        {
            Debug.LogWarning("No dialogue lines added!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Press Space to continue
        {
            NextLine();
        }
    }

    public void StartDialogue()
    {
        currentLineIndex = 0;
        ShowLine();
    }

    public void ShowLine()
    {
        if (currentLineIndex > dialogueLines.Count) // if index exceeds the dialogue line count
        {
            EndDialogue();
            return;
        }

        if (currentLineIndex < dialogueLines.Count)
        {
            if (!isTyping)// Start typing the next line
            {
                typingCoroutine = StartCoroutine(TypeLine(dialogueLines[currentLineIndex]));
            }
            else // Skip typing and show the full line
            {
                StopCoroutine(typingCoroutine);
                dialogueText.text = dialogueLines[currentLineIndex];
                isTyping = false;
            }
        }
    }

    IEnumerator TypeLine(string line) //types character by character
    {
        isTyping = true;
        dialogueText.text = ""; // Clear current text

        foreach (char c in line.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    public void NextLine()
    {
        if (!isTyping)
        {
            currentLineIndex++;
            ShowLine();
        }
    }

    public void EndDialogue()
    {
        Debug.Log("Dialogue ended.");
        dialogueText.text = ""; // Clear the dialogue box
    }
}
