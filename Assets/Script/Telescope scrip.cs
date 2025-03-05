using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telescopescrip : MonoBehaviour
{

    public GameObject room, camera, highlight;
    
    private void OnMouseEnter()
    {
        ToggleHighlight();
    }

    public void ToggleHighlight()
    {
        highlight.SetActive(!highlight.activeInHierarchy);
    }

    private void OnMouseExit()
    {
        ToggleHighlight();
    }
    private void OnMouseUp()
    {
        camera.transform.position = new Vector3(room.transform.position.x, room.transform.position.y, camera.transform.position.z);
    }

}
