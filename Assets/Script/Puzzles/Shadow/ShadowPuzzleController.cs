using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPuzzleController : MonoBehaviour
{
    public GameObject lastSelected;
    public void SetLastSelected(GameObject SetLastSelected)
    {
        lastSelected = SetLastSelected;
        Debug.Log("new selected object: " + lastSelected);
    }

    public float turnSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lastSelected != null)
        {
                if (Input.GetMouseButton(1))
            {
                Vector3 transformVector = new Vector3(0, 0, -turnSpeed * Time.deltaTime);
                lastSelected.transform.Rotate(transformVector);
                Debug.Log("Turning left.");
            }
        }
    }
}
