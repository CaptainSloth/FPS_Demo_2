using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExample : MonoBehaviour {

    private MCP_EventMaster eventMasterScript;

    private void Start()
    {
        SetInitRef();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " has entered");  
        eventMasterScript.Call_GE();
        Destroy(gameObject);
    }

    void SetInitRef()
    {
        eventMasterScript = GameObject.Find("MasterControlProgram").GetComponent<MCP_EventMaster>();
    }
}
