using System.Collections;
using UnityEngine;

public class Enemy_CollisionField : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private Rigidbody rbStrikingPlayer;
    private int dmgToApply;
    public float massRequirement = 50;
    public float speedRequirement = 5;
    private float dmgFactor = 0.1f;

    void OnEnable()
    {
        SetInitRef();
        enemyMaster.EventEnemyDie += DisableThis;
    }

    void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableThis;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            rbStrikingPlayer = other.GetComponent<Rigidbody>();

            if(rbStrikingPlayer.mass >= massRequirement && rbStrikingPlayer.velocity.sqrMagnitude > speedRequirement * speedRequirement)
            {
                dmgToApply = (int)(dmgFactor * rbStrikingPlayer.mass * rbStrikingPlayer.velocity.magnitude);
                enemyMaster.CallEventEnemyDeductHealth(dmgToApply);
            }
        }   
    }

    void SetInitRef()
    {
        enemyMaster = transform.root.GetComponent<Enemy_Master>();
    }

    void DisableThis()
    {
        this.enabled = false;
    }
}
