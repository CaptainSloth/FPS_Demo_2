using System.Collections;
using UnityEngine;

public class Item_Colliders : MonoBehaviour {

    private Item_Master item_Master;
    public Collider[] colliders;
    public PhysicMaterial _PhysicsMaterial;

    private void OnEnable()
    {
        SetInitRef();
        CheckIfStartsInInventory();
        item_Master.EventObjectThrow += EnableColliders;
        item_Master.EventObjectPickup += DisableColliders;
    }

    private void OnDisable()
    {
        item_Master.EventObjectThrow -= EnableColliders;
        item_Master.EventObjectPickup -= DisableColliders;
    }

    void SetInitRef()
    {
        item_Master = GetComponent<Item_Master>();
        colliders = GetComponentsInChildren<Collider>();
    }

    void CheckIfStartsInInventory()
    {
        if (transform.root.CompareTag(MCP_References._playerTag))
        {
            DisableColliders();
        }
    }

    void EnableColliders()
    {
        if(colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                col.enabled = true;

                if(_PhysicsMaterial != null)
                {
                    col.material = _PhysicsMaterial;
                }
            }
        }
    }

    void DisableColliders()
    {
        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                col.enabled = false;
            }
        }
    }
}
