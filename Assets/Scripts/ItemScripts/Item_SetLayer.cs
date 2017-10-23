using System.Collections;
using UnityEngine;

public class Item_SetLayer : MonoBehaviour {

    private Item_Master item_Master;
    public string itemThrowLayer;
    public string itemPickupLayer;

	void OnEnable () 
	{
        SetInitRef();
        item_Master.EventObjectPickup += SetItemToPickupLayer;
        item_Master.EventObjectThrow += SetItemToThrowLayer;
    }
	
	void OnDisable () 
	{
        item_Master.EventObjectPickup -= SetItemToPickupLayer;
        item_Master.EventObjectThrow -= SetItemToThrowLayer;
    }

    void Start()
    {
        SetLayerOnEnable();
    }

    void SetInitRef()
    {
        item_Master = GetComponent<Item_Master>();
    }

    void SetItemToThrowLayer()
    {
        SetLayer(transform, itemThrowLayer);
    }

    void SetItemToPickupLayer()
    {
        SetLayer(transform, itemPickupLayer);
    }

    void SetLayerOnEnable()
    {
        if(itemPickupLayer == "")
        {
            itemPickupLayer = "Item";
        }

        if(itemThrowLayer== "")
        {
            itemThrowLayer = "Item";
        }

        if (transform.root.CompareTag(MCP_References._playerTag))
        {
            SetItemToPickupLayer();
        }
        else
        {
            SetItemToThrowLayer();
        }
    }

    void SetLayer(Transform _transform, string itemLayerName)
    {
        _transform.gameObject.layer = LayerMask.NameToLayer(itemLayerName);

        foreach(Transform child in _transform)
        {
            SetLayer(child, itemLayerName);
        }
    }

}
