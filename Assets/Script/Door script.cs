using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorscript : MonoBehaviour
{

    public GameObject room, camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseUp()
    {
        camera.transform.position = new Vector3(room.transform.position.x, room.transform.position.y, camera.transform.position.z);
    }

}
