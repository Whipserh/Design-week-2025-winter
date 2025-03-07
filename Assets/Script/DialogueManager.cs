using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject textBox;
    public DialogueSequence firstDialogue;
    public DialogueSequence currentDialogue;

    private TextMeshProUGUI textComponent;

    public float delay;

    [HideInInspector]
    public bool isDialogueRunning = false;

    private bool waiting = false;
    private int lineNumber;

    private void Start()
    {
        textComponent = textBox.GetComponentInChildren<TextMeshProUGUI>();
        StartDialogue(firstDialogue);
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0) && waiting)
        {
            waiting = false;
            if (lineNumber + 1 < currentDialogue.dialogue.Length) lineNumber++;
            else
            {
                lineNumber = 0;
                textBox.SetActive(false);
                isDialogueRunning = false;
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

    public void StartDialogue(DialogueSequence DialogueSquence)
    {
        isDialogueRunning = true;
        currentDialogue = DialogueSquence;
        StartCoroutine(scrollingDialogue());
    }
}
