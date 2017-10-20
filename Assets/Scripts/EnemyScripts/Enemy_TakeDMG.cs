using System.Collections;
using UnityEngine;

public class Enemy_TakeDMG : MonoBehaviour {

    private Enemy_Master enemyMaster;
    public int dmgMultiplier = 1;
    public bool shouldRemoveCollider;

    void OnEnable()
    {
        SetInitRef();
        enemyMaster.EventEnemyDie += RemoveThis;
    }

    void OnDisable()
    {
        enemyMaster.EventEnemyDie -= RemoveThis;
    }

    void SetInitRef()
    {
        enemyMaster = transform.root.GetComponent<Enemy_Master>();
    }

    public void ProcessDMG(int dmg)
    {
        int dmgToApply = dmg * dmgMultiplier;
        enemyMaster.CallEventEnemyDeductHealth(dmgToApply);
    }

    void RemoveThis()
    {
        if (shouldRemoveCollider)
        {
            if (GetComponent<Collider>() != null)
            {
                Destroy(GetComponent<Collider>());
            }

            if (GetComponent<Rigidbody>() != null)
            {
                Destroy(GetComponent<Rigidbody>());
            }
        }
        Destroy(this);
    }



}
