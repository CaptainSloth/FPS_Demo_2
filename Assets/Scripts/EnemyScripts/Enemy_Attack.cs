using System.Collections;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private Transform attackTarget;
    private Transform _transform;
    public float attackRate = 1;
    private float nextAttack;
    public float attackRange = 3.5f;
    public int attackDMG = 10;


    void OnEnable()
    {
        SetInitRef();
        enemyMaster.EventEnemyDie += DisableThis;
        enemyMaster.EventEnemySetNavTarget += SetAttackTarget;
    }

    void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableThis;
        enemyMaster.EventEnemySetNavTarget -= SetAttackTarget;
    }

    void Update()
    {
        TryToAttack();

    }

    void SetInitRef()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        _transform = transform;
    }
	
    void SetAttackTarget(Transform targetTransform)
    {
        attackTarget = targetTransform;
    }

    void TryToAttack()
    {
        if(attackTarget != null)
        {
            if(Time.time > nextAttack)
            {
                nextAttack = Time.time + attackRate;
                if(Vector3.Distance(_transform.position, attackTarget.position)<= attackRange)
                {
                    Vector3 lookAtVector = new Vector3(attackTarget.position.x, _transform.position.y, attackTarget.position.z);
                    _transform.LookAt(lookAtVector);
                    enemyMaster.CallEventEnemyAttack();
                    enemyMaster.isOnRoute = false;
                }
            }
        }
    }

    public void OnEnemyAttack() //called by hpunch animation
    {
        if(attackTarget != null)
        {
            if(Vector3.Distance(_transform.position, attackTarget.position)<=attackRange&&attackTarget.GetComponent<Player_Master>() != null)
            {
                Vector3 toOther = attackTarget.position - _transform.position;

                if(Vector3.Dot(toOther, _transform.forward) > 0.5f)
                {
                    attackTarget.GetComponent<Player_Master>().CallEventPlayerHealthDeduction(attackDMG);
                }
            }
        }
    }

    void DisableThis()
    {
    this.enabled = false;
    }

}
