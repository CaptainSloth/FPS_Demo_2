using System.Collections;
using UnityEngine;

public class Item_Ammo : MonoBehaviour {

    private Item_Master item_Master;
    public GameObject playerGO;
    public string ammoName;
    public int quantity;
    public bool isTriggerPickup;

    void OnEnable()
    {
        SetInitRef();
        item_Master.EventObjectPickup += TakeAmmo;
    }

    void OnDisable()
    {
        item_Master.EventObjectPickup -= TakeAmmo;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(MCP_References._playerTag) && isTriggerPickup)
        {
            TakeAmmo();
        }
    }

    void Start()
    {
        SetInitRef();
    }

    void SetInitRef()
    {
        item_Master = GetComponent<Item_Master>();
        playerGO = MCP_References._player;

        if (isTriggerPickup)
        {
            if (GetComponent<Collider>() !=null)
            {
                GetComponent<Collider>().isTrigger = true;
            }

            if(GetComponent<Rigidbody>() != null)
            {
                GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    void TakeAmmo()
    {
        playerGO.GetComponent<Player_Master>().CallEventPickedUpAmmo(ammoName, quantity);
        Destroy(gameObject);
    }
}
