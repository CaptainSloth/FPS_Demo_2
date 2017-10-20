using System.Collections;
using UnityEngine;

public class Enemy_Health : MonoBehaviour {

    private Enemy_Master enemyMaster;
    public int enemyHealth = 100;
    public float healthLow = 25;

    void OnEnable()
    {
        SetInitRef();
        enemyMaster.EventEnemyDeductHealth += DeductHealth;
        enemyMaster.EventEnemyIncreaseHealth += IncreaseHealth;
    }

    void OnDisable()
    {
        enemyMaster.EventEnemyDeductHealth -= DeductHealth;
        enemyMaster.EventEnemyIncreaseHealth -= IncreaseHealth;
    }

    void SetInitRef()
    {
        enemyMaster = GetComponent<Enemy_Master>();
    }
    
    void DeductHealth(int healthChange)
    {
        enemyHealth -= healthChange;
        if(enemyHealth <= 0)
        {
            enemyHealth = 0;
            enemyMaster.CalleventEnemyDie();
            Destroy(gameObject, Random.Range(10, 20));
        }

        CheckHealthFraction();
    }

    void CheckHealthFraction()
    {
        if(enemyHealth <= healthLow && enemyHealth > 0)
        {
            enemyMaster.CallEventEnemyHealthLow();
        }

        else if(enemyHealth > healthLow)
        {
            enemyMaster.CallEventEnemyHealthRecovered();
        }
    }

    void IncreaseHealth(int healthChange)
    {
        enemyHealth += healthChange;
        if (enemyHealth > 100)
        {
            enemyHealth = 100;
        }

        CheckHealthFraction();
    }

}
