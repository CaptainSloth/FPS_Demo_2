using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_NavDestinationReached : MonoBehaviour {

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
        if (GetComponent<NavMeshAgent>() != null)
        {
            _NavMeshAgent = GetComponent<NavMeshAgent>();
        }
        checkRate = Random.Range(0.3f, 0.4f);
    }

    void Update()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            CheckIfDestinationReached();
        }
    }

    void CheckIfDestinationReached()
    {
        if (enemyMaster.isOnRoute)
        {
            if(_NavMeshAgent.remainingDistance < _NavMeshAgent.stoppingDistance)
            {
                enemyMaster.isOnRoute = false;
                enemyMaster.CallEventEnemyReachedNavTarget();
            }
        }
    }

    void DisableThis()
    {
        if (_NavMeshAgent != null)
        {
            _NavMeshAgent.enabled = false;
        }

        this.enabled = false;
    }

}
