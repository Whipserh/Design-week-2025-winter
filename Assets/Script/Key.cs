using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public LockedDoor doorToUnlock;

    private void Start()
    {
        doorToUnlock.locks++;
    }

    private void OnMouseUp()
    {
        doorToUnlock.Unlock();
        doorToUnlock.gameObject.active = false;
    }
}
