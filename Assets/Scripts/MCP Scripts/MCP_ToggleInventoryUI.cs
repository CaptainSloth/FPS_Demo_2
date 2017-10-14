using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCP_ToggleInventoryUI : MonoBehaviour {

    [Tooltip("Does this game mode have an inventory? Set to true if if so.")]
    public bool hasInventory;
    public GameObject inventoryUI;
    public string toggleInventoryButton;
    private MCP_Master mcp_Master;

    // Use this for initialization
    void Start ()
    {
        SetInitRef();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckforInventoryUIToggleRequest();
	}

    void SetInitRef()
    {
        mcp_Master = GetComponent<MCP_Master>();

        if(toggleInventoryButton == "")
        {
            Debug.LogWarning("TYPE IN THE NAME OF THE BUTTON USED FOR INVENTORY DUMMY.");
            this.enabled = false;
        }
    }

    void CheckforInventoryUIToggleRequest()
    {
        if(Input.GetButtonUp(toggleInventoryButton) && !mcp_Master.isMenuOn && !mcp_Master.isGameOver && hasInventory)
        {
            ToggleInventoryUI();
        }
    }

    public void ToggleInventoryUI()
    {
        if(inventoryUI != null)
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            mcp_Master.isInventoryUIOn = !mcp_Master.isInventoryUIOn;
            mcp_Master.CallEventInventoryUIToggle();
        }
    }
}
