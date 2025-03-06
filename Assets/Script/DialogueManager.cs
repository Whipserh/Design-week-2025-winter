using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject textBox;
    public DialogueSequence testDialogue;
    public DialogueSequence currentDialogue;

    private TextMeshProUGUI textComponent;

    public float delay;

    private bool waiting = false;
    private int lineNumber;

    private void Start()
    {
        textComponent = textBox.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && waiting)
        {
            waiting = false;
            if (lineNumber + 1 < currentDialogue.dialogue.Length) lineNumber++;
            else
            {
                lineNumber = 0;
                textBox.SetActive(false);
                return;
            }
            StartCoroutine(scrollingDialogue());
        }
    }

    IEnumerator scrollingDialogue()
    {
        textBox.SetActive(true);

        textComponent.text = currentDialogue.dialogue[lineNumber];

        textComponent.maxVisibleCharacters = 0;
        int characterCount = textComponent.text.Length;

        while (textComponent.maxVisibleCharacters < characterCount)
        {
            textComponent.maxVisibleCharacters++;
            yield return new WaitForSeconds(delay);
        }

        waiting = true;
        StopCoroutine(scrollingDialogue());
    }

    [ContextMenu ("test dialogue")]
    private void forceDialogue()
    {
        currentDialogue = testDialogue;
        StartCoroutine(scrollingDialogue());
    }

    public void startDialogue(DialogueSequence DialogueSquence)
    {
        currentDialogue = DialogueSquence;
        StartCoroutine(scrollingDialogue());
    }
}
