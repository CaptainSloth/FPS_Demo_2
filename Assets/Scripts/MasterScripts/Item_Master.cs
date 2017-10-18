using System.Collections;
using UnityEngine;

public class Item_Master : MonoBehaviour {

    private Player_Master player_Master;

    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EventObjectThrow;
    public event GeneralEventHandler EventObjectPickup;

    public delegate void PickActionEventHandler(Transform item);
    public event PickActionEventHandler EventPickupAction;

    private void OnEnable()
    {
        SetInitRef();

    }

    public void CallEventObjectThrow()
    {
        if(EventObjectThrow != null)
        {
            EventObjectThrow();
        }
        player_Master.CallEventHandsEmpty();
        player_Master.CallEventInventoryChanged();
    }

    public void CallEventObjectPickup()
    {
        if(EventObjectPickup != null)
        {
            EventObjectPickup();
        }
        player_Master.CallEventInventoryChanged();
    }

    public void CallEventPickupAction(Transform item)
    {
        if(EventPickupAction != null)
        {
            EventPickupAction(item);
        }
    }

    void SetInitRef()
    {
        if(MCP_References._player != null)
        {
            player_Master = MCP_References._player.GetComponent<Player_Master>();
        }
        
    }



}
