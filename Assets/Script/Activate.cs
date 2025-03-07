using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public GameObject target;

        private void OnMouseUp()
    {
        target.active = true;
    }
}
