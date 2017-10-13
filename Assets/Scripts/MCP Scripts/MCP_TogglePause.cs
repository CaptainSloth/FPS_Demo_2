using System.Collections;
using UnityEngine;

public class MCP_TogglePause : MonoBehaviour {

    private MCP_Master mcp_Master;
    private bool isPaused;

    private void OnEnable()
    {
        SetInitRef();
        mcp_Master.MenuToggleEvent += TogglePause;
        mcp_Master.InventoryUIToggleEvent += TogglePause;
    }

    private void OnDisable()
    {
        mcp_Master.MenuToggleEvent -= TogglePause;
        mcp_Master.InventoryUIToggleEvent -= TogglePause;
    }

    void SetInitRef()
    {
        mcp_Master = GetComponent<MCP_Master>();
    }

    void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

}
