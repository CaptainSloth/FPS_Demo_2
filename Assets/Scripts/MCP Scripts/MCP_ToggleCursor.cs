using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCP_ToggleCursor : MonoBehaviour {

    private MCP_Master mcp_Master;
    private bool isCursorLocked = true;

    private void OnEnable()
    {
        SetInitRef();
        mcp_Master.MenuToggleEvent += ToggleCursorState;
        mcp_Master.InventoryUIToggleEvent += ToggleCursorState;
    }

    private void OnDisable()
    {
        mcp_Master.MenuToggleEvent -= ToggleCursorState;
        mcp_Master.InventoryUIToggleEvent -= ToggleCursorState;
    }

    private void Update()
    {
        CheckIfCursorShouldBeLocked();
    }

    void SetInitRef()
    {
        mcp_Master = GetComponent<MCP_Master>();
    }

    void ToggleCursorState()
    {
        isCursorLocked = !isCursorLocked;
    }

    void CheckIfCursorShouldBeLocked()
    {
        if (isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
