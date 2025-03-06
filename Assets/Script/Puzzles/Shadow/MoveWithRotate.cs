using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MoveWithRotate : MonoBehaviour
{
    // Start is called before the first frame update
    [Description("This needs a 2d box collider to move the objects.")]

    public bool moving;

    public ShadowPuzzleController Controller;

    public Vector2 lastPosition;


    // Start is called before the first frame update
    void Start()
    {
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        //gets the current location of the mouse
        Vector2 mouselocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (moving)
        {
            //gets how far the mouse travelled between frames
            Vector2 distanceTravelled = mouselocation - lastPosition;

            //adds that distance travelled from the last frame to the game object
            transform.position += (Vector3)distanceTravelled;



        }//updates the last positson of the mouse
        lastPosition = mouselocation;
    }




    //lets the player move the item
    private void OnMouseDown()
    {
        lastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moving = true;
        Controller.SendMessage("SetLastSelected", gameObject);
    }
    private void OnMouseUp()
    {
        moving = false;
    }
}
