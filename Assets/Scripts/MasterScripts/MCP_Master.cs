using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCP_Master : MonoBehaviour {

    public delegate void MCP_EventHandler();
    public event MCP_EventHandler MenuToggleEvent;
    public event MCP_EventHandler InventoryUIToggleEvent;
    public event MCP_EventHandler RestartLevelEvent;
    public event MCP_EventHandler GoToMenuSceneEvent;
    public event MCP_EventHandler GameOverEvent;

    public bool isGameOver;
    public bool isInventoryUIOn;
    public bool isMenuOn;

    public void CallEventMenuToggle()
    {
        if(MenuToggleEvent != null)
        {
            MenuToggleEvent();
        }

    }

    public void CallEventInventoryUIToggle()
    {
        if (InventoryUIToggleEvent != null)
        {
            InventoryUIToggleEvent();
        }

    }

    public void CallEventRestartLevel()
    {
        if (RestartLevelEvent != null)
        {
            RestartLevelEvent();
        }

    }
    
    public void CallGoToMenuScene()
    {
        if (GoToMenuSceneEvent != null)
        {
            GoToMenuSceneEvent();
        }

    }

    public void CallEventGameOver()
    {
        if (GameOverEvent != null)
        {
            isGameOver = true;
            GameOverEvent();
        }

    }
}
