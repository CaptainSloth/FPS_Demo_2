using System.Collections;
using UnityEngine;

public class Item_Animator : MonoBehaviour {

    private Item_Master item_Master;
    public Animator _animator;

    void OnEnable()
    {
        SetInitRef();
        item_Master.EventObjectThrow += DisableAnimator;
        item_Master.EventObjectPickup += EnableAnimator;

    }

    void OnDisable()
    {
        item_Master.EventObjectThrow -= DisableAnimator;
        item_Master.EventObjectPickup -= EnableAnimator;
    }

    void SetInitRef()
    {
        item_Master = GetComponent<Item_Master>();
    }

    void EnableAnimator()
    {
        if(_animator != null)
        {
            _animator.enabled = true;
        }
    }

    void DisableAnimator()
    {
        if (_animator != null)
        {
            _animator.enabled = false;
        }
    }

}
