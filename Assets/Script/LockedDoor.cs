using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{

    public GameObject room, camera, highlight;
    public DialogueSequence nextDialogue;

    private bool isLocked = true;

    private DialogueManager dm;

    private void Start()
    {
        dm = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }
    private void OnMouseEnter()
    {
        if (dm.isDialogueRunning) return;
        ToggleHighlight();
    }

    public void ToggleHighlight()
    {
        highlight.SetActive(!highlight.activeInHierarchy);
    }

    private void OnMouseExit()
    {
        if (dm.isDialogueRunning) return;
        ToggleHighlight();
    }

    private void OnMouseUp()
    {
        if (dm.isDialogueRunning) return;
        if (isLocked) return;
        if (nextDialogue != null)  dm.StartDialogue(nextDialogue);
        camera.transform.position = new Vector3(room.transform.position.x, room.transform.position.y, camera.transform.position.z);
    }

    public void Unlock()
    {
        isLocked = false;
    }
}
