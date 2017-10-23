using System.Collections;
using UnityEngine;

public class Item_SetPos : MonoBehaviour {

    private Item_Master item_Master;
    public Vector3 itemLocalPos;

    void OnEnable () 
	{
        SetInitRef();
        item_Master.EventObjectPickup += SetPosOnPlayer;
	}
	
	void OnDisable () 
	{
        item_Master.EventObjectPickup -= SetPosOnPlayer;
    }

    void Start()
    {
        SetPosOnPlayer();
    }

    void SetInitRef()
    {
        item_Master = GetComponent<Item_Master>();
    }

    void SetPosOnPlayer()
    {
        if (transform.root.CompareTag(MCP_References._playerTag))
        {
            transform.localPosition = itemLocalPos;
        }
    }

}
