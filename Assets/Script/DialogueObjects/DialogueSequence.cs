using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogueSequence", menuName = "CustomObjects/Dialogue Sequence")]
public class DialogueSequence : ScriptableObject
{
    public string[] dialogue;
}
