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
            //Place the item on the mouse
            transform.position = mouselocation;
        }

    }




    //lets the player move the item
    private void OnMouseDown()
    {
        moving = true;
        Controller.SendMessage("SetLastSelected", gameObject);
    }
    private void OnMouseUp()
    {
        moving = false;
    }
}
