using System.Collections;
using UnityEngine;

public class Gun_Ammo : MonoBehaviour {

    private Player_Master player_Master;
    private Gun_Master gun_Master;
    private Player_AmmoBox ammoBox;
    private Animator _animator;

    public int clipSize;
    public int currentAmmo;
    public string ammoName;
    public float reloadTime;

    void OnEnable()
    {
        SetInitRef();
        StartingSanityCheck();
        CheckAmmoStatus();

        gun_Master.EventPlayerInput += DeductAmmo;
        gun_Master.EventPlayerInput += CheckAmmoStatus;
        gun_Master.EventRequestReload += TryToReload;
        gun_Master.EventGunNotUsable += TryToReload;
        gun_Master.EventRequestGunReset += ResetGunReloading;

        if(player_Master != null)
        {
            player_Master.EventAmmoChanged += UIAmmoUpdateRequest;
        }

        if(ammoBox != null)
        {
            StartCoroutine(UpdateAmmoUIWhenEnabling());
        }
    }

    void OnDisable()
    {
        gun_Master.EventPlayerInput -= DeductAmmo;
        gun_Master.EventPlayerInput -= CheckAmmoStatus;
        gun_Master.EventRequestReload -= TryToReload;
        gun_Master.EventGunNotUsable -= TryToReload;
        gun_Master.EventRequestGunReset -= ResetGunReloading;

        if (player_Master != null)
        {
            player_Master.EventAmmoChanged -= UIAmmoUpdateRequest;
        }
    }

    void Start()
    {
        SetInitRef();
        StartCoroutine(UpdateAmmoUIWhenEnabling());

        if (player_Master != null)
        {
            player_Master.EventAmmoChanged += UIAmmoUpdateRequest;
        }
    }

    void SetInitRef()
    {
        gun_Master = GetComponent<Gun_Master>();

        if(GetComponent<Animator>() != null)
        {
            _animator = GetComponent<Animator>();
        }

        if(MCP_References._player != null)
        {
            player_Master = MCP_References._player.GetComponent<Player_Master>();
            ammoBox = MCP_References._player.GetComponent<Player_AmmoBox>();
        }
    }

    void DeductAmmo()
    {
        currentAmmo--;
        UIAmmoUpdateRequest();
    }

    void TryToReload()
    {
        for (int i = 0; i < ammoBox.typesOfAmmunition.Count; i++)
        {
            if(ammoBox.typesOfAmmunition[i].ammoName == ammoName)
            {
                if(ammoBox.typesOfAmmunition[i].ammoCurrentCarried > 0 && currentAmmo != clipSize && !gun_Master.isReloading)
                {
                    gun_Master.isReloading = true;
                    gun_Master.isGunLoaded = false;

                    if(_animator != null)
                    {
                        _animator.SetTrigger("Reload");
                    }
                    else
                    {
                        StartCoroutine(ReloadWithoutAnimation());
                    }
                }
                break;
            }
        }
    }

    void CheckAmmoStatus()
    {
        if(currentAmmo <= 0)
        {
            currentAmmo = 0;
            gun_Master.isGunLoaded = false;
        }

        else if(currentAmmo > 0)
        {
            gun_Master.isGunLoaded = true;
        }
    }

    void StartingSanityCheck()
    {
        if(currentAmmo > clipSize)
        {
            currentAmmo = clipSize;
        }
    }

    void UIAmmoUpdateRequest()
    {
        for (int i = 0; i < ammoBox.typesOfAmmunition.Count; i++)
        {
            if(ammoBox.typesOfAmmunition[i].ammoName == ammoName)
            {
                gun_Master.CallEventAmmoChanged(currentAmmo, ammoBox.typesOfAmmunition[i].ammoCurrentCarried);
                break;
            }
        }
    }

    void ResetGunReloading()
    {
        gun_Master.isReloading = false;
        CheckAmmoStatus();
        UIAmmoUpdateRequest();
    }

    public void OnReloadComplete()                  //Called by the reload animation
    {
        for (int i = 0; i < ammoBox.typesOfAmmunition.Count; i++)
        {
            if(ammoBox.typesOfAmmunition[i].ammoName == ammoName)
            {
                int ammoRefill = clipSize - currentAmmo;

                if(ammoBox.typesOfAmmunition[i].ammoCurrentCarried >= ammoRefill)
                {
                    currentAmmo += ammoRefill;
                    ammoBox.typesOfAmmunition[i].ammoCurrentCarried -= ammoRefill;
                }

                else if(ammoBox.typesOfAmmunition[i].ammoCurrentCarried < ammoRefill && ammoBox.typesOfAmmunition[i].ammoCurrentCarried != 0)
                {
                    currentAmmo += ammoBox.typesOfAmmunition[i].ammoCurrentCarried;
                    ammoBox.typesOfAmmunition[i].ammoCurrentCarried = 0;
                }

                break;
            }
        }
        ResetGunReloading();
    }

    IEnumerator ReloadWithoutAnimation()
    {
        yield return new WaitForSeconds(reloadTime);
        OnReloadComplete();
    }

    IEnumerator UpdateAmmoUIWhenEnabling()
    {
        yield return new WaitForSeconds(0.05f);     //fudge factor to make sure the UI is updated when chaging weapons...
        UIAmmoUpdateRequest();
    }

}
