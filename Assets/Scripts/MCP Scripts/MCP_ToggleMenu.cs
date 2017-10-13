using System.Collections;
using UnityEngine;

public class MCP_ToggleMenu : MonoBehaviour {

    private MCP_Master mcp_Master;
    public GameObject menu;

    // Use this for initialization
    void Start ()
    {
        ToggleMenu();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckForMenuToggleRequest();
	}

    private void OnEnable()
    {
        SetInitRef();
        mcp_Master.GameOverEvent += ToggleMenu;
    }

    private void OnDisable()
    {
        mcp_Master.GameOverEvent -= ToggleMenu;
    }

    void SetInitRef()
    {
        mcp_Master = GetComponent<MCP_Master>();
    }

    void CheckForMenuToggleRequest()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && !mcp_Master.isGameOver && !mcp_Master.isInventoryUIOn)
        {
            ToggleMenu();
        }
    }
    
    void ToggleMenu()
    {
        if(menu != null)
        {
            menu.SetActive(!menu.activeSelf);
            mcp_Master.isMenuOn = !mcp_Master.isMenuOn;
            mcp_Master.CallEventMenuToggle();
        }
        else
        {
            Debug.LogWarning("YOU NEED TO ASSIGN A UI GAMEOBJECT TO THE TOGGLE MENU IN MCP STUPID!!!");
        }
    }
}
