using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour {


    public LayerMask detectionLayer;
    private Transform _transform;
    private NavMeshAgent _NavMeshAgent;
    private Collider[] hitCol;
    private float checkRate;
    private float nextCheck;
    [SerializeField]
    private float detectionRadius = 10;

	// Use this for initialization
	void Start () {
        SetInitRef();
	}
	
	// Update is called once per frame
	void Update () {
        CheckIfPlayerInRange();
	}

    void SetInitRef()
    {
        _transform = transform;
        _NavMeshAgent = GetComponent<NavMeshAgent>();
        checkRate = Random.Range(0.8f, 1.2f);
    }

    void CheckIfPlayerInRange()
    {
        if(Time.time>nextCheck && _NavMeshAgent.enabled == true)
        {
            nextCheck = Time.time + checkRate;

            hitCol = Physics.OverlapSphere(_transform.position, detectionRadius, detectionLayer);

            if (hitCol.Length > 0)
            {
                _NavMeshAgent.SetDestination(hitCol[0].transform.position);
            }
        }
    }


}
