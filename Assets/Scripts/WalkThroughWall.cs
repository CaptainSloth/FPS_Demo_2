using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkThroughWall : MonoBehaviour {

    private Color NSColor = new Color(0, 0, 1, 0.3f);
    private Color defaultColor = new Color(1, 1, 1, 1);
    private MCP_EventMaster eventMasterScript;

    void OnEnable()
    {
        SetInitRef();
        eventMasterScript._GE += SetLayerToNotSolid;
    }

    void OnDisable()
    {
        eventMasterScript._GE -= SetLayerToNotSolid;
    }

    public void SetLayerToNotSolid()
    {
        gameObject.layer = LayerMask.NameToLayer("Not Solid");
        GetComponent<Renderer>().material.color = NSColor;
    }

    void SetInitRef()
    {
        eventMasterScript = GameObject.Find("MasterControlProgram").GetComponent<MCP_EventMaster>();
    }
}
