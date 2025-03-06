using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [Description("This needs a 2d box collider to move the objects.")]

    public bool moving;
    protected float previousAngle;
    public float outerBoundery, innerBoundery;

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
        Vector2 direction = mouselocation - (Vector2) transform.position;
        float currentAngle = Mathf.Atan2(direction.y, direction.x);


        Debug.Log(Vector2.Distance(transform.position, mouselocation));
        if (Input.GetMouseButton(0) && pointOnSection(mouselocation))//if the player is holding the left click button and is selecting the section

        {
            float changeAngle = currentAngle - previousAngle;

            //gets how far the mouse travelled between frames
            transform.Rotate(new Vector3(0,0,changeAngle*Mathf.Rad2Deg));
        }//updates the last positson of the mouse
        previousAngle = currentAngle;
    }//end update














    public bool pointOnSection(Vector2 point)
    {
        float distance = Vector2.Distance(transform.position, point);
        // we aren't in the section
        return innerBoundery <= distance && distance <= outerBoundery; // distance from point to origin of circle is within the boundary
    }


}
