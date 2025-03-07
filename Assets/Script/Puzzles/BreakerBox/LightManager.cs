using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public GameObject doorToUnlock;
    
    private int numOfLights;
    private int greenLights;

    public void Add()
    {
        numOfLights++;
    }

    public void CompleteCheck(bool isRed)
    {
        if (isRed) greenLights--;
        else greenLights++;

        if (greenLights == numOfLights) doorToUnlock.GetComponent<LockedDoor>().Unlock();
    }
}
