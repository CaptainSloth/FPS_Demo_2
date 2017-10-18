using System.Collections;
using UnityEngine;

public class Item_Throw : MonoBehaviour {

    private Item_Master item_Master;
    private Transform _transform;
    private Rigidbody _rb;
    private Vector3 throwDirection;

    public bool canBeThrown;
    public string throwButtonName;
    public float throwForce;

	void Start () 
	{
        SetInitRef();
	}
	
	void Update () 
	{
        CheckForThrowInput();
	}

    void SetInitRef()
    {
        item_Master = GetComponent<Item_Master>();
        _transform = transform;
        _rb = GetComponent<Rigidbody>();
    }

    void CheckForThrowInput()
    {
        if(throwButtonName != null)
        {
            if(Input.GetButtonDown(throwButtonName) && Time.timeScale > 0 && canBeThrown && _transform.root.CompareTag(MCP_References._playerTag))
            {
                CarryOutThrowActions();
            }
        }
    }

    void CarryOutThrowActions()
    {
        throwDirection = _transform.parent.forward;
        _transform.parent = null;
        item_Master.CallEventObjectThrow();
        TossItem();
    }

    void TossItem()
    {
        _rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
    }

}
