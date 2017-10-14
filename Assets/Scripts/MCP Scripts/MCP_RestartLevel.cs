using UnityEngine;
using UnityEngine.SceneManagement;

public class MCP_RestartLevel : MonoBehaviour {

    private MCP_Master mcp_Master;

    private void OnEnable()
    {
        SetInitRef();
        mcp_Master.RestartLevelEvent += RestartLevel;
    }

    private void OnDisable()
    {
        mcp_Master.RestartLevelEvent += RestartLevel;
    }

    void SetInitRef()
    {
        mcp_Master = GetComponent<MCP_Master>();
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
