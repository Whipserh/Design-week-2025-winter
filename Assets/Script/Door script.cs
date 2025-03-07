using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorscript : MonoBehaviour
{

    public GameObject room, camera;
    public DialogueSequence nextDialogue;

    private DialogueManager dm;

    private void Start()
    {
        dm = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    private void OnMouseUp()
    {
        if (dm.isDialogueRunning) return;
        if (nextDialogue != null)  dm.StartDialogue(nextDialogue);
        camera.transform.position = new Vector3(room.transform.position.x, room.transform.position.y, camera.transform.position.z);
    }

}
