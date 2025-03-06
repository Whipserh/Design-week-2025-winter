using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LeverBehavior : MonoBehaviour
{
    private Camera mainCam;

    private const float maximumHeightDist = 0.625f;

    private Vector2 leverInitialPos;
    private Vector2 mouseInitialPos;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void OnMouseDown()
    {
        leverInitialPos = transform.localPosition;
        mouseInitialPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        //gets how far the mouse is from where you clicked it
        Vector2 distanceTravelled = mouseInitialPos - mousePos;

        //adds that distance travelled from the last frame to the game object
        transform.localPosition = new Vector2(0, Mathf.Clamp(leverInitialPos.y - distanceTravelled.y, -maximumHeightDist, maximumHeightDist));
    }
}
