using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Inventory : MonoBehaviour {

    public Transform inventoryPlayerParent;
    public Transform inventoryUIParent;
    public string itemTag;
    public GameObject uiButton;

    private Player_Master player_Master;
    private MCP_ToggleInventoryUI inventoryUIScript;
    private float timeToPlaceInHands = 0.1f;
    private Transform currentlyHeldItem;
    private int counter;
    private string buttonText;
    private List<Transform> listInventory = new List<Transform>();


    private void OnEnable()
    {
        SetInitRef();
        UpdateInventoryListAndUI();
        CheckIfHandsEmpty();

        player_Master.EventInventoryChanged += UpdateInventoryListAndUI;
        player_Master.EventInventoryChanged += CheckIfHandsEmpty;
        player_Master.EventHandsEmpty += ClearHands;
    }

    private void OnDisable()
    {
        player_Master.EventInventoryChanged -= UpdateInventoryListAndUI;
        player_Master.EventInventoryChanged -= CheckIfHandsEmpty;
        player_Master.EventHandsEmpty -= ClearHands;
    }

    void SetInitRef()
    {
        inventoryUIScript = GameObject.Find("MasterControlProgram").GetComponent<MCP_ToggleInventoryUI>();
        player_Master = GetComponent<Player_Master>();
    }

    void UpdateInventoryListAndUI()
    {
        counter = 0;
        listInventory.Clear();
        listInventory.TrimExcess();

        ClearInvetoryUI();

        foreach(Transform child in inventoryPlayerParent)
        {
            if (child.CompareTag(itemTag))
            {
                listInventory.Add(child);
                GameObject go = Instantiate(uiButton) as GameObject;
                buttonText = child.name;
                go.GetComponentInChildren<Text>().text = buttonText;
                int index = counter;
                go.GetComponent<Button>().onClick.AddListener(delegate { ActivateInventoryItem(index); });
                go.GetComponent<Button>().onClick.AddListener(inventoryUIScript.ToggleInventoryUI);
                go.transform.SetParent(inventoryUIParent, false);
                counter++;
            }
        }
    }

    void CheckIfHandsEmpty()
    {
        if(currentlyHeldItem == null && listInventory.Count >0)
        {
            StartCoroutine(PlaceItemInHands(listInventory[listInventory.Count - 1]));
        }
    }

    void ClearHands()
    {
        currentlyHeldItem = null;
    }

    void ClearInvetoryUI()
    {
        foreach(Transform child in inventoryUIParent)
        {
            Destroy(child.gameObject);
        }
    }

    public void ActivateInventoryItem(int inventoryIndex)
    {
        DeactivateAllInventoryItems();
        StartCoroutine(PlaceItemInHands(listInventory[inventoryIndex]));
    }

    void DeactivateAllInventoryItems()
    {
        foreach (Transform child in inventoryPlayerParent)
        {
            if (child.CompareTag(itemTag))
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator PlaceItemInHands(Transform itemTransform)
    {
        yield return new WaitForSeconds(timeToPlaceInHands);
        currentlyHeldItem = itemTransform;
        currentlyHeldItem.gameObject.SetActive(true);

    }
}
