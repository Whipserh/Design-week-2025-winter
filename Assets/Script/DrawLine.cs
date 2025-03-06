using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject line;
    public Camera mainCamera;

    public float lineThickness;

    private GameObject currentLine;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0;

            currentLine = Instantiate(line, worldPos, Quaternion.identity);
            currentLine.transform.localScale = new Vector2(lineThickness, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            currentLine.GetComponent<LineBehavior>().enabled = false;
        }
    }
}
