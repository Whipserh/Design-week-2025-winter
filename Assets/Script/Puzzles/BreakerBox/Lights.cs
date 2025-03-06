using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    private Color red = new Color(0.754717f, 0.01186654f, 0.01186654f);
    private Color green = new Color(0.05490196f, 0.7529412f, 0.01186654f);

    private bool isRed = true;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    public void SwapLights()
    {
        if (isRed) sr.color = green;
        else sr.color = red;
        isRed = !isRed;
    }
}
