using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MCP_TogglePlayer : MonoBehaviour {

    public FirstPersonController playerController;
    private MCP_Master mcp_Master;

    private void OnEnable()
    {
        SetInitRef();
        mcp_Master.MenuToggleEvent += TogglePlayerController;
        mcp_Master.InventoryUIToggleEvent += TogglePlayerController;
    }

    private void OnDisable()
    {
        mcp_Master.MenuToggleEvent -= TogglePlayerController;
        mcp_Master.InventoryUIToggleEvent -= TogglePlayerController;
    }

    void SetInitRef()
    {
        mcp_Master = GetComponent<MCP_Master>();
    }


    void TogglePlayerController()
    {
        if(playerController != null)
        {
            playerController.enabled = !playerController.enabled;
        }
    }

}
