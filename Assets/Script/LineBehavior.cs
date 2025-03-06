using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBehavior : MonoBehaviour
{
    public Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(mouse);

        //Rotate towards the mouse
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        //Scale just enough to reach the mouse
        transform.localScale = new Vector2(transform.localScale.x, lookDir.magnitude);

    }
}
