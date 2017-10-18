using System.Collections;
using UnityEngine;

public class Item_Pickup : MonoBehaviour {

    private Item_Master item_Master;

    void OnEnable()
    {
        SetInitRef();
        item_Master.EventPickupAction += CarryOutPickupActions;
    }

    void OnDisable()
    {
        item_Master.EventPickupAction -= CarryOutPickupActions;
    }

    void SetInitRef()
    {
        item_Master = GetComponent<Item_Master>();
    }

    void CarryOutPickupActions(Transform tParent)
    {
        transform.SetParent(tParent);
        item_Master.CallEventObjectPickup();
        transform.gameObject.SetActive(false);
    }

}
