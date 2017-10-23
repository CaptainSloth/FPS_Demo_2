using System.Collections;
using UnityEngine;

public class Item_RigidBody : MonoBehaviour {

    private Item_Master item_Master;
    public Rigidbody[] rbs;

	void OnEnable () 
	{
        SetInitRef();
        item_Master.EventObjectThrow += SetIsKinematicToFalse;
        item_Master.EventObjectPickup += SetIsKinematicToTrue;
    }
	
	void OnDisable () 
	{
        item_Master.EventObjectThrow -= SetIsKinematicToFalse;
        item_Master.EventObjectPickup -= SetIsKinematicToTrue;
    }

    void Start()
    {
        CheckifStartsInInventory();
    }

    void SetInitRef()
    {
        item_Master = GetComponent<Item_Master>();
        rbs = GetComponentsInChildren<Rigidbody>();
    }

    void CheckifStartsInInventory()
    {
        if (transform.root.CompareTag(MCP_References._playerTag))
        {
            SetIsKinematicToTrue();
        }
    }

    void SetIsKinematicToTrue()
    {
        if(rbs.Length > 0)
        {
            foreach (Rigidbody rb in rbs)
            {
                rb.isKinematic = true;
            }
        }
    }

    void SetIsKinematicToFalse()
    {
        if (rbs.Length > 0)
        {
            foreach (Rigidbody rb in rbs)
            {
                rb.isKinematic = false;
            }
        }
    }

}
