using System.Collections;
using UnityEngine;

public class Item_Name : MonoBehaviour {

    public string itemName;

    void Start()
    {
        SetItemName();
    }

    void SetItemName()
    {
        transform.name = itemName;
    }

}
