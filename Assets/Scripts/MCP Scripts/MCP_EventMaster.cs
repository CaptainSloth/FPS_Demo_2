using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCP_EventMaster : MonoBehaviour {

    public delegate void GeneralEvents();
    public event GeneralEvents _GE;

    public void Call_GE()
    {
        if (_GE != null)
        {
            _GE();
        }
    }
}
