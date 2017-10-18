using System.Collections;
using UnityEngine;

public class Item_SetRot : MonoBehaviour {

    private Item_Master item_Master;
    public Quaternion itemLocalRot;

    void OnEnable()
    {
        SetInitRef();
        SetRotOnPlayer();
        item_Master.EventObjectPickup += SetRotOnPlayer;
    }

    void OnDisable()
    {
        item_Master.EventObjectPickup -= SetRotOnPlayer;
    }

    void SetInitRef()
    {
        item_Master = GetComponent<Item_Master>();
    }

    void SetRotOnPlayer()
    {
        if (transform.root.CompareTag(MCP_References._playerTag))
        {
            transform.localRotation = itemLocalRot;
        }
    }

}
