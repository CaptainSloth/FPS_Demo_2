using UnityEngine;
using UnityEngine.SceneManagement;

public class MCP_GoToMenuScene : MonoBehaviour {

    private MCP_Master mcp_Master;

    private void OnEnable()
    {
        SetInitRef();
        mcp_Master.GoToMenuSceneEvent += GoToMenuScene;
    }

    private void OnDisable()
    {
        mcp_Master.GoToMenuSceneEvent -= GoToMenuScene;
    }

    void SetInitRef()
    {
        mcp_Master = GetComponent<MCP_Master>();
    }

    void GoToMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
