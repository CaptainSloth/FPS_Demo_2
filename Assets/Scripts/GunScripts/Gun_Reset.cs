using System.Collections;
using UnityEngine;

public class Gun_Reset : MonoBehaviour {

    private Gun_Master gun_Master;
    private Item_Master item_Master;

    void OnEnable()
    {
        SetInitRef();

        if(item_Master != null)
        {
            item_Master.EventObjectThrow += ResetGun;
        }
    }

    void OnDisable()
    {
        if (item_Master != null)
        {
            item_Master.EventObjectThrow -= ResetGun;
        }
    }

    void SetInitRef()
    {
        gun_Master = GetComponent<Gun_Master>();
        
        if(GetComponent<Item_Master>() != null)
        {
            item_Master = GetComponent<Item_Master>();
        }
    }

    void ResetGun()
    {
        gun_Master.CallEventRequestGunReset();
    }
}
