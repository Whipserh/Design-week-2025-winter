using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class starVisible : MonoBehaviour
{
    public List<GameObject> starPosRed = new List<GameObject>();
    public List<GameObject> starPosBlue = new List<GameObject>();
    public List<GameObject> linePosRed = new List<GameObject>();
    public List<GameObject> linePosBlue = new List<GameObject>();
    public List<GameObject> linePosPurple = new List<GameObject>();
    public List<bool> starActive = new List<bool>();

    public GameObject redFilm;
    public GameObject blueFilm;


    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject starPos in starPosRed)
        {
            starPos.SetActive(false);
        }

        foreach (GameObject starPos in starPosBlue)
        {
            starPos.SetActive(false);
        }

        foreach (GameObject linePos in linePosRed)
        {
            linePos.SetActive(false);
        }

        foreach (GameObject linePos in linePosBlue)
        {
            linePos.SetActive(false);
        }

        foreach (GameObject linePos in linePosPurple)
        {
            linePos.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //check blue stars
        foreach (GameObject starPos in starPosRed)
        {
            if (isInRange(starPos, redFilm))
            {
                starPos.SetActive(true);
            }
            else
            {
                if (starPos.activeInHierarchy == true)
                {
                    starPos.SetActive(true);
                }
                else
                {
                    starPos.SetActive(false);
                }
            }
        }

        //check red stars
        foreach (GameObject starPos in starPosBlue)
        {
            if (isInRange(starPos, blueFilm))
            {
                starPos.SetActive(true);
            }
            else
            {
                if (starPos.activeInHierarchy == true)
                {
                    starPos.SetActive(true);
                }
                else
                {
                    starPos.SetActive(false);
                }
            }
        }

        //check blue lines
        foreach (GameObject linePos in linePosRed)
        {
            if (isInRange(linePos, redFilm))
            {
                linePos.SetActive(true);
            }
            else
            {
                if (linePos.activeInHierarchy == true)
                {
                    linePos.SetActive(true);
                }
                else
                {
                    linePos.SetActive(false);
                }
            }
        }

        //check red lines
        foreach (GameObject linePos in linePosBlue)
        {
            if (isInRange(linePos, blueFilm))
            {
                linePos.SetActive(true);
            }
            else
            {
                if (linePos.activeInHierarchy == true)
                {
                    linePos.SetActive(true);
                }
                else
                {
                    linePos.SetActive(false);
                }
            }
        }

        //check purple lines
        foreach (GameObject linePos in linePosPurple)
        {
            if (isInRange(linePos, blueFilm) && isInRange(linePos, redFilm))
            {
                linePos.SetActive(true);
            }
            else
            {
                if (linePos.activeInHierarchy == true)
                {
                    linePos.SetActive(true);
                }
                else
                {
                    linePos.SetActive(false);
                }
            }
        }
    }

    private bool isInRange(GameObject checkingObject, GameObject movingObject)
    {
        if (checkingObject.transform.position.x <= (movingObject.transform.position.x + (movingObject.transform.localScale.x / 2)) && checkingObject.transform.position.x >= (movingObject.transform.position.x - (movingObject.transform.localScale.x / 2)) && checkingObject.transform.position.y <= (movingObject.transform.position.y + (movingObject.transform.localScale.y / 2)) && checkingObject.transform.position.y >= (movingObject.transform.position.y - (movingObject.transform.localScale.y / 2))) return true;
        return false;
    }
}
