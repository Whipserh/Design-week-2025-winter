using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public LockedDoor doorToUnlock;
    
    private int numOfLights;
    private int greenLights;

    private void Start()
    {
        doorToUnlock.locks++;
    }

    public void Add()
    {
        numOfLights++;
    }

    public void CompleteCheck(bool isRed)
    {
        if (isRed) greenLights--;
        else greenLights++;

        if (greenLights == numOfLights) doorToUnlock.Unlock();
    }
}
