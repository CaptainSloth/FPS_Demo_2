using System.Collections;
using UnityEngine;

public class Enemy_RagdollToggle : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private Collider _collider;
    private Rigidbody _rb;

    void OnEnable()
    {
        SetInitRef();
        enemyMaster.EventEnemyDie += ActivateRagdoll;
    }

    void OnDisable()
    {
        enemyMaster.EventEnemyDie -= ActivateRagdoll;
    }

    void SetInitRef()
    {
        enemyMaster = transform.root.GetComponent<Enemy_Master>();

        if (GetComponent<Collider>() != null)
        {
            _collider = GetComponent<Collider>();
        }

        if (GetComponent<Rigidbody>() != null)
        {
            _rb = GetComponent<Rigidbody>();
        }
    }

    void ActivateRagdoll()
    {
        if(_rb != null)
        {
            _rb.isKinematic = false;
            _rb.useGravity = true;
        }

        if(_collider != null)
        {
            _collider.isTrigger = false;
            _collider.enabled = true;
        }
    }

}
