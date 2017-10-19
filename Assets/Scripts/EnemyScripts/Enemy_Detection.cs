using System.Collections;
using UnityEngine;

public class Enemy_Detection : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private Transform _transform;
    public Transform head;
    public LayerMask playerLayer;
    public LayerMask sightLayer;
    private float checkRate;
    private float nextCheck;
    private float detectRadius = 80;
    private RaycastHit hit;    

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
        _transform = transform;

        if(head == null)
        {
            head = _transform;
        }

        checkRate = Random.Range(0.8f, 1.2f);
    }

    void Update () 
	{
        CarryOutDetection();
	}

    void CarryOutDetection()
    {
        if(Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;

            Collider[] colliders = Physics.OverlapSphere(_transform.position, detectRadius, playerLayer);

            if(colliders.Length > 0)
            {
                foreach (Collider potentialTargetCollider in colliders)
                {
                    if (potentialTargetCollider.CompareTag(MCP_References._playerTag))
                    {
                        if (CanPotentialTargetBeSeen(potentialTargetCollider.transform))
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                enemyMaster.CallEventEnemyLostTarget();
            }
        }
    }

    bool CanPotentialTargetBeSeen(Transform potentialTarget)
    {
        if(Physics.Linecast(head.position, potentialTarget.position, out hit, sightLayer))
        {
            if(hit.transform == potentialTarget)
            {
                enemyMaster.CallEventEnemySetNavTarget(potentialTarget);
                return true;
            }
            else
            {
                enemyMaster.CallEventEnemyLostTarget();
                return false;
            }
        }
        else
        {
            enemyMaster.CallEventEnemyLostTarget();
            return false;
        }
    }

    void DisableThis()
    {
        this.enabled = false;
    }
}

