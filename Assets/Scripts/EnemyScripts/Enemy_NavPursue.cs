using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_NavPursue : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private NavMeshAgent _NavMeshAgent;
    private float checkRate;
    private float nextCheck;

    void OnEnable()
    {
        SetInitRef();
        enemyMaster.EventEnemyDie += DisableThis;

    }

    void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableThis;
    }

    void SetInitRef()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        if(GetComponent<NavMeshAgent>() != null)
        {
            _NavMeshAgent = GetComponent<NavMeshAgent>();
        }
        checkRate = Random.Range(0.1f, 0.2f);
    }

    void Update()
    {
        if(Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            TryToChaseTarget();
        }
    }

    void TryToChaseTarget()
    {
        if(enemyMaster._target !=null && _NavMeshAgent !=null && !enemyMaster.isNavPaused)
        {
            _NavMeshAgent.SetDestination(enemyMaster._target.position);

            if(_NavMeshAgent.remainingDistance > _NavMeshAgent.stoppingDistance)
            {
                enemyMaster.CallEventEnemyWalking();
                enemyMaster.isOnRoute = true;
            }
        }
    }

    void DisableThis()
    {
        if(_NavMeshAgent != null)
        {
            _NavMeshAgent.enabled = false;
        }

        this.enabled = false;
    }

}
