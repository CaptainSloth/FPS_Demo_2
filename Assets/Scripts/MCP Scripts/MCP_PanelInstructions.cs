using System.Collections;
using UnityEngine;

public class MCP_PanelInstructions : MonoBehaviour {

    public GameObject panelInstructions;
    private MCP_Master mcp_Master;

    private void OnEnable()
    {
        SetInitRef();
        mcp_Master.GameOverEvent += TurnOffPanelInstructions;
    }

    private void OnDisable()
    {
        mcp_Master.GameOverEvent -= TurnOffPanelInstructions;
    }

    void SetInitRef()
    {
        mcp_Master = GetComponent<MCP_Master>();
    }

    void TurnOffPanelInstructions()
    {
        if(panelInstructions != null)
        {
            panelInstructions.SetActive(false);
        }
    }

}
