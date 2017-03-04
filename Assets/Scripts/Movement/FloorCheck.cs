using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCheck : MonoBehaviour {

    private bool onFloor = false;

    public bool OnFloor
    {
        get
        {
            return onFloor;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        onFloor = true;
    }

    public void OnTriggerExit(Collider other)
    {
        onFloor = false;
    }
}
