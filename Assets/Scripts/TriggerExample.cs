using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExample : MonoBehaviour {

    private WalkThroughWall WTWScript;

    private void Start()
    {
        SetInitRef();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " has entered");  
        WTWScript.SetLayerToNotSolid();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + " has exited");
        WTWScript.SetLayerToDefault();
    }

    //private void OnTriggerStay(Collider other)
    //{
    //   //  Debug.Log(other.name + " is in the trigger");
    //}

    void SetInitRef()
    {
        if (GameObject.Find("Wall") != null)
        {
            WTWScript = GameObject.Find("Wall").GetComponent<WalkThroughWall>();
        }
        
    }
}
