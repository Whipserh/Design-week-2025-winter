using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LeverBehavior : MonoBehaviour
{
    public List<Lights> affectedLights;
    
    private Camera mainCam;

    private const float maximumHeightDist = 1.22f;

    private Vector2 leverInitialPos;
    private Vector2 mouseInitialPos;

    private bool isON = false;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        if (transform.localPosition.y > maximumHeightDist / 10 && isON) return;
        if (transform.localPosition.y < maximumHeightDist / 10 * 9 && !isON) return;
        foreach(Lights target in affectedLights)
        {
            target.SwapLights();
        }
        isON = !isON;
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
        transform.localPosition = new Vector2(leverInitialPos.x, Mathf.Clamp(leverInitialPos.y - distanceTravelled.y, 0, maximumHeightDist));
    }
}
