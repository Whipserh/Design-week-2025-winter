using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class starVisibilityChangeUM : MonoBehaviour
{
    public List<GameObject> starPosRed = new List<GameObject>();
    public List<GameObject> starPosBlue = new List<GameObject>();
    public List<GameObject> linePosRed = new List<GameObject>();
    public List<GameObject> linePosBlue = new List<GameObject>();
    public List<GameObject> linePosPurple = new List<GameObject>();
    public List<bool> starActive = new List<bool>();
    public List<GameObject> constellationParts = new List<GameObject>();

    public GameObject redFilm1;
    public GameObject redFilm2;
    public GameObject redFilm3;
    public GameObject redFilm4;
    public GameObject redFilm5;
    public GameObject blueFilm1;
    public GameObject blueFilm2;
    public GameObject blueFilm3;
    public GameObject blueFilm4;
    public GameObject blueFilm5;

    bool gameFinished = false;

    public LockedDoor doorToUnlock;


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

        doorToUnlock.locks++;
    }


    // Update is called once per frame
    void Update()
    {
        if (gameFinished == false)
        {
            //check blue stars
            foreach (GameObject starPos in starPosRed)
            {
                if (isInRange(starPos, redFilm1) || isInRange(starPos, redFilm2) || isInRange(starPos, redFilm3) || isInRange(starPos, redFilm4) || isInRange(starPos, redFilm5))
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
                if (isInRange(starPos, blueFilm1) || isInRange(starPos, blueFilm2) || isInRange(starPos, blueFilm3) || isInRange(starPos, blueFilm4) || isInRange(starPos, blueFilm5))
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
                if (isInRange(linePos, redFilm1) || isInRange(linePos, redFilm2) || isInRange(linePos, redFilm3) || isInRange(linePos, redFilm4) || isInRange(linePos, redFilm5))
                {
                    linePos.SetActive(true);
                }
                else
                {
                    linePos.SetActive(false);
                }
            }

            //check red lines
            foreach (GameObject linePos in linePosBlue)
            {
                if (isInRange(linePos, blueFilm1) || isInRange(linePos, blueFilm2) || isInRange(linePos, blueFilm3) || isInRange(linePos, blueFilm4) || isInRange(linePos, blueFilm5))
                {
                    linePos.SetActive(true);
                }
                else
                {
                    linePos.SetActive(false);
                }
            }

            //check purple lines
            foreach (GameObject linePos in linePosPurple)
            {
                if (isInRange(linePos, blueFilm1) && isInRange(linePos, redFilm1))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm1) && isInRange(linePos, redFilm2))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm1) && isInRange(linePos, redFilm3))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm1) && isInRange(linePos, redFilm4))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm1) && isInRange(linePos, redFilm5))
                {
                    linePos.SetActive(true);
                }

                else if (isInRange(linePos, blueFilm2) && isInRange(linePos, redFilm1))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm2) && isInRange(linePos, redFilm2))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm2) && isInRange(linePos, redFilm3))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm2) && isInRange(linePos, redFilm4))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm2) && isInRange(linePos, redFilm5))
                {
                    linePos.SetActive(true);
                }

                else if (isInRange(linePos, blueFilm3) && isInRange(linePos, redFilm1))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm3) && isInRange(linePos, redFilm2))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm3) && isInRange(linePos, redFilm3))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm3) && isInRange(linePos, redFilm4))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm3) && isInRange(linePos, redFilm5))
                {
                    linePos.SetActive(true);
                }

                else if (isInRange(linePos, blueFilm4) && isInRange(linePos, redFilm1))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm4) && isInRange(linePos, redFilm2))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm4) && isInRange(linePos, redFilm3))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm4) && isInRange(linePos, redFilm4))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm4) && isInRange(linePos, redFilm5))
                {
                    linePos.SetActive(true);
                }

                else if (isInRange(linePos, blueFilm5) && isInRange(linePos, redFilm1))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm5) && isInRange(linePos, redFilm2))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm5) && isInRange(linePos, redFilm3))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm5) && isInRange(linePos, redFilm4))
                {
                    linePos.SetActive(true);
                }
                else if (isInRange(linePos, blueFilm5) && isInRange(linePos, redFilm5))
                {
                    linePos.SetActive(true);
                }


                else
                {
                    linePos.SetActive(false);
                }
            }

            foreach (GameObject part in constellationParts)
            {
                if (part.activeInHierarchy == false)
                {
                    gameFinished = false;
                    break;
                }
                gameFinished = true;
                doorToUnlock.Unlock();
            }
        }

        else
        {
            redFilm1.GetComponent<Movement>().enabled = false;
            redFilm2.GetComponent<Movement>().enabled = false;
            redFilm3.GetComponent<Movement>().enabled = false;
            redFilm4.GetComponent<Movement>().enabled = false;
            redFilm5.GetComponent<Movement>().enabled = false;
            blueFilm1.GetComponent<Movement>().enabled = false;
            blueFilm2.GetComponent<Movement>().enabled = false;
            blueFilm3.GetComponent<Movement>().enabled = false;
            blueFilm4.GetComponent <Movement>().enabled = false;
            blueFilm5.GetComponent<Movement>().enabled = false;
        }

    }

    private bool isInRange(GameObject checkingObject, GameObject movingObject)
    {
        if (checkingObject.transform.position.x <= (movingObject.transform.position.x + (movingObject.transform.localScale.x / 2)) && checkingObject.transform.position.x >= (movingObject.transform.position.x - (movingObject.transform.localScale.x / 2)) && checkingObject.transform.position.y <= (movingObject.transform.position.y + (movingObject.transform.localScale.y / 2)) && checkingObject.transform.position.y >= (movingObject.transform.position.y - (movingObject.transform.localScale.y / 2))) return true;
        return false;
    }


}