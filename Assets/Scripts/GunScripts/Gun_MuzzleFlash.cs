using System.Collections;
using UnityEngine;

public class Gun_MuzzleFlash : MonoBehaviour {

    public ParticleSystem muzzleFlash;
    private Gun_Master gun_Master;

    void OnEnable()
    {
        SetInitRef();
        gun_Master.EventPlayerInput += PlayMuzzleFlash;
    }

    void OnDisable()
    {
        gun_Master.EventPlayerInput -= PlayMuzzleFlash;
    }

    void SetInitRef()
    {
        gun_Master = GetComponent<Gun_Master>();
    }

    void PlayMuzzleFlash()
    {
        if(muzzleFlash != null)
        {
            muzzleFlash.Play();
        }
    }

}
