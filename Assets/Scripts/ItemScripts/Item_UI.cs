using System.Collections;
using UnityEngine;

public class Item_UI : MonoBehaviour {

    private Item_Master item_Master;
    public GameObject _UI;

    void OnEnable()
    {
        SetInitRef();
        item_Master.EventObjectPickup += EnableItemUI;
        item_Master.EventObjectThrow += DisableItemUI;
    }

    void OnDisable()
    {
        item_Master.EventObjectPickup -= EnableItemUI;
        item_Master.EventObjectThrow -= DisableItemUI;
    }

    void SetInitRef()
    {
        item_Master = GetComponent<Item_Master>();
    }

    void EnableItemUI()
    {
        if(_UI != null)
        {
            _UI.SetActive(true);
        }
    }

    void DisableItemUI()
    {
        if (_UI != null)
        {
            _UI.SetActive(false);
        }
    }

}
