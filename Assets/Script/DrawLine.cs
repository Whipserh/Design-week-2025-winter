using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawLine : MonoBehaviour
{
    public GameObject line;

    public float lineThickness;

    [System.Serializable]
    public class Coordinates
    {
        public Transform point1;
        public Transform point2;
        public GameObject line;
        public bool isComplete;
    }

    [SerializeField]
    public Coordinates[] desiredLinePoints;

    public DialogueSequence endingLine;

    public TextMeshProUGUI completeText;

    private GameObject currentLine;
    private Camera mainCamera;

    private Vector2 linePoint1;
    private Vector2 linePoint2;

    private int completedLines = 0;
    private int requiredLines = 0;

    private DialogueManager dm;

    private bool isGameFinished = false;

    void Start()
    {
        mainCamera = Camera.main;

        foreach (Coordinates coordinates in desiredLinePoints)
        {
            coordinates.line.SetActive(false);
            requiredLines++;
        }

        dm = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    void Update()
    {
        if (dm.isDialogueRunning) return;
        if (isGameFinished)
        {
            completeText.enabled = true;
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0;
            linePoint1 = worldPos;

            currentLine = Instantiate(line, worldPos, Quaternion.identity);
            currentLine.transform.localScale = new Vector2(lineThickness, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0;
            linePoint2 = worldPos;

            foreach (Coordinates coordinates in desiredLinePoints)
            {
                float point1Dist = (linePoint1 - (Vector2)coordinates.point1.position).magnitude;
                //print("Point 1 distance: " + point1Dist);
                float point2Dist = (linePoint2 - (Vector2)coordinates.point2.position).magnitude;
                //print("Point 2 distance: " + point2Dist);
                if (point1Dist < 1 && point2Dist < 1)
                {
                    coordinates.line.SetActive(true);
                    if (!coordinates.isComplete) completedLines++;
                    coordinates.isComplete = true;
                }
                if ((linePoint1 - (Vector2)coordinates.point2.position).magnitude < 0.2f && (linePoint2 - (Vector2)coordinates.point1.position).magnitude < 0.2f)
                {
                    coordinates.line.SetActive(true);
                    if (!coordinates.isComplete) completedLines++;
                    coordinates.isComplete = true;
                }
            }
            Destroy(currentLine);

            if (completedLines == requiredLines)
            {
                dm.StartDialogue(endingLine);
                isGameFinished = true;
            }
        }
    }
}
