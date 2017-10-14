using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour {

    private MCP_Master mcp_Master;
    private Player_Master player_Master;
    public int playerHealth;
    public Text healthText;

    private void OnEnable()
    {
        SetInitRef();
        SetUI();
        player_Master.EventPlayerHealthDeduction += DeductHealth;
        player_Master.EventPlayerHealthIncrease += IncreaseHealth;
    }

    private void OnDisable()
    {
        player_Master.EventPlayerHealthDeduction -= DeductHealth;
        player_Master.EventPlayerHealthIncrease -= IncreaseHealth;
    }

    void Start()
    {
       // StartCoroutine(TestHealthDeduction());
    }

    void SetInitRef()
    {
        mcp_Master = GameObject.Find("MasterControlProgram").GetComponent<MCP_Master>();
        player_Master = GetComponent<Player_Master>();
    }

    IEnumerator TestHealthDeduction()
    {
        yield return new WaitForSeconds(2);
        //DeductHealth(50);
        player_Master.CallEventPlayerHealthDeduction(50);
    }

    void DeductHealth(int healthChange)
    {
        playerHealth -= healthChange;

        if(playerHealth <= 0)
        {
            playerHealth = 0;
            mcp_Master.CallEventGameOver();
        }

        SetUI();
    }

    void IncreaseHealth(int healthChange)
    {
        playerHealth += healthChange;

        if(playerHealth > 100)
        {
            playerHealth = 100;
        }

        SetUI();
    }

    void SetUI()
    {
        healthText.text = playerHealth.ToString();
    }

}
