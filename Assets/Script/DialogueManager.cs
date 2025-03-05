using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textBox;

    public DialogueSequence testDialogue;

    public DialogueSequence currentDialogue;

    public float delay;

    private bool waiting = false;

    private int lineNumber;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && waiting)
        {
            waiting = false;
            if (lineNumber + 1 < currentDialogue.dialogue.Length) lineNumber++;
            else
            {
                Debug.LogError("Close dialogue box not implemented");
                lineNumber = 0;
                return;
            }
            StartCoroutine(scrollingDialogue());
        }
    }

    IEnumerator scrollingDialogue()
    {
        textBox.text = currentDialogue.dialogue[lineNumber];
        
        textBox.maxVisibleCharacters = 0;
        int characterCount = textBox.text.Length;

        while (textBox.maxVisibleCharacters < characterCount)
        {
            textBox.maxVisibleCharacters++;
            yield return new WaitForSeconds(delay);
        }

        startWait();
        StopCoroutine(scrollingDialogue());
    }

    [ContextMenu ("test dialogue")]
    private void forceDialogue()
    {
        currentDialogue = testDialogue;
        _startDialogue();
    }

    private void _startDialogue()
    {
        StartCoroutine(scrollingDialogue());
    }

    public void startDialogue(DialogueSequence DialogueSquence)
    {
        currentDialogue = DialogueSquence;
        _startDialogue();
    }

    private void startWait()
    {
        
        waiting = true;
    }
}
