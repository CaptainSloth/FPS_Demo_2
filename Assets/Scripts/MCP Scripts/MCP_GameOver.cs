using UnityEngine;

public class MCP_GameOver : MonoBehaviour {

    private MCP_Master mcp_Master;
    public GameObject panelGameOver;

    private void OnEnable()
    {
        SetInitRef();
        mcp_Master.GameOverEvent += ActivateGameOverPanel;
    }

    private void OnDisable()
    {
        mcp_Master.GameOverEvent -= ActivateGameOverPanel;
    }

    void SetInitRef()
    {
        mcp_Master = GetComponent<MCP_Master>();
    }

    void ActivateGameOverPanel()
    {
        if(panelGameOver != null)
        {
            panelGameOver.SetActive(true);
        }
    }
}
