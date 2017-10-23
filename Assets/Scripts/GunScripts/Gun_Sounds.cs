using System.Collections;
using UnityEngine;

public class Gun_Sounds : MonoBehaviour {

    private Gun_Master gun_Master;
    private Transform _transform;
    public float shootVolume = 0.4f;
    public float reloadVolume = 0.5f;
    public AudioClip[] shootSound;
    public AudioClip reloadSound;

    void OnEnable()
    {
        SetInitRef();
        gun_Master.EventPlayerInput += PlayShootSound;
    }

    void OnDisable()
    {
        gun_Master.EventPlayerInput -= PlayShootSound;
    }

    void SetInitRef()
    {
        gun_Master = GetComponent<Gun_Master>();
        _transform = transform;
    }

    void PlayShootSound()
    {
        if(shootSound.Length > 0)
        {
            int index = Random.Range(0, shootSound.Length);
            AudioSource.PlayClipAtPoint(shootSound[index], _transform.position, shootVolume);
        }
    }

    public void PlayReloadSound()   //Called by the reload Animation event
    {
        if(reloadSound != null)
        {
            AudioSource.PlayClipAtPoint(reloadSound, _transform.position, reloadVolume);
        }
    }
}
