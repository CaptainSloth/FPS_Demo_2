using System.Collections;
using UnityEngine;

public class Gun_Animator : MonoBehaviour {

    private Gun_Master gun_Master;
    private Animator _animator;

    void OnEnable()
    {
        SetInitRef();
        gun_Master.EventPlayerInput += PlayShootAnimation;
    }

    void OnDisable()
    {
        gun_Master.EventPlayerInput -= PlayShootAnimation;
    }

    void SetInitRef()
    {
        gun_Master = GetComponent<Gun_Master>();

        if(GetComponent<Animator>() != null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    void PlayShootAnimation()
    {
        if(_animator != null)
        {
            _animator.SetTrigger("Shoot");
        }
    }

}
