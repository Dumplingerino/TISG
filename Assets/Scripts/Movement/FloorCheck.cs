using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCheck : MonoBehaviour {

    private int  onFloor = 0;

    public bool OnFloor
    {
        get
        {
            return onFloor > 0;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        onFloor++;
    }

    public void OnTriggerExit(Collider other)
    {
        onFloor--;
    }
}
