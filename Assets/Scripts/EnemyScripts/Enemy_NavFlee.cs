using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_NavFlee : MonoBehaviour {

    public bool isFleeing;
    private Enemy_Master enemyMaster;
    private NavMeshAgent _NavMeshAgent;
    private NavMeshHit navHit;
    private Transform _transform;
    public Transform fleeTarget;
    private Vector3 runPos;
    private Vector3 dirToPlayer;
    public float fleeRange = 25;
    private float checkRate;
    private float nextCheck;

    void OnEnable()
    {
        SetInitRef();
        enemyMaster.EventEnemyDie += DisableThis;
        enemyMaster.EventEnemySetNavTarget += SetFleeTarget;
        enemyMaster.EventEnemyHealthLow += IShouldFlee;
        enemyMaster.EventEnemyHealthRecovered += IShouldStopFleeing;
    }

    void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableThis;
        enemyMaster.EventEnemySetNavTarget -= SetFleeTarget;
        enemyMaster.EventEnemyHealthLow -= IShouldFlee;
        enemyMaster.EventEnemyHealthRecovered -= IShouldStopFleeing;
    }

	void Update () 
	{
		if(Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;

            CheckIfIShouldFlee();
        }
	}

    void SetInitRef()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        _transform = transform;
        if(GetComponent<NavMeshAgent>() != null)
        {
            _NavMeshAgent = GetComponent<NavMeshAgent>();
        }
        checkRate = Random.Range(0.3f, 0.4f);
    }

    void SetFleeTarget(Transform target)
    {
        fleeTarget = target;
    }

    void IShouldFlee()
    {
        isFleeing = true;

        if(GetComponent<Enemy_NavPursue>() != null)
        {
            GetComponent<Enemy_NavPursue>().enabled = false;
        }
    }

    void IShouldStopFleeing()
    {
        isFleeing = false;
        if(GetComponent<Enemy_NavPursue>() != null)
        {
            GetComponent<Enemy_NavPursue>().enabled = true;
        }
    }

    void CheckIfIShouldFlee()
    {
        if (isFleeing)
        {
            if(fleeTarget !=null && !enemyMaster.isOnRoute && !enemyMaster.isNavPaused)
            {
                if(FleeTarget(out runPos)&& Vector3.Distance(_transform.position, fleeTarget.position) < fleeRange)
                {
                    _NavMeshAgent.SetDestination(runPos);
                    enemyMaster.CallEventEnemyWalking();
                    enemyMaster.isOnRoute = true;
                }
            }
        }
    }

    bool FleeTarget(out Vector3 result)
    {
        dirToPlayer = _transform.position - fleeTarget.position;
        Vector3 checkPos = _transform.position + dirToPlayer;

        if (NavMesh.SamplePosition(checkPos, out navHit, 1.0f, NavMesh.AllAreas))
        {
            result = navHit.position;
            return true;
        }
        else
        {
            result = _transform.position;
            return false;
        }
    }

    void DisableThis()
    {
        this.enabled = false;
    }
}
