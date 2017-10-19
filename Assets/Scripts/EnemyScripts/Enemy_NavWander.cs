using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_NavWander : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private NavMeshAgent _NavMeshAgent;
    private float checkRate;
    private float nextCheck;
    private float wanderRange = 10;
    private Transform _transform;
    private NavMeshHit navHit;
    private Vector3 wanderTarget;

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
        _transform = transform;
    }

    void Update()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            CheckIfIShouldWander();
        }
    }

    void CheckIfIShouldWander()
    {
        if (enemyMaster._target == null && !enemyMaster.isOnRoute && !enemyMaster.isNavPaused)
        {
            if (RandomWanderTarget(_transform.position, wanderRange, out wanderTarget))
            {
                _NavMeshAgent.SetDestination(wanderTarget);
                enemyMaster.isOnRoute = true;
                enemyMaster.CallEventEnemyWalking();
            }
        }
         
    }

    bool RandomWanderTarget(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        if(NavMesh.SamplePosition(randomPoint, out navHit, 1.0f, NavMesh.AllAreas))
        {
            result = navHit.position;
            return true;
        }
        else
        {
            result = center;
            return true;
        }
    }

    void DisableThis()
    {
        this.enabled = false;
    }

}
