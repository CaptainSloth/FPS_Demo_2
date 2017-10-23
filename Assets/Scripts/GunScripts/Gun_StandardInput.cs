using System.Collections;
using UnityEngine;

public class Gun_StandardInput : MonoBehaviour {

    private Gun_Master gun_Master;
    private float nextAttack;
    public float attackRate = 0.5f;
    private Transform _transform;
    public bool isAutomatic;
    public bool hasBurstFire;
    private bool isBurstFireActive;
    public string attackButtonName;
    public string reloadButtonName;
    public string burstFireButtonName;

    void Start()
    {
        SetInitRef();    
    }

    void Update () 
	{
        CheckIfWeaponShouldAttack();
        CheckForBurstFireToggle();
        CheckForReloadRequest();
	}

    void SetInitRef()
    {
        gun_Master = GetComponent<Gun_Master>();
        _transform = transform;
        gun_Master.isGunLoaded = true; //player can attempt to shoot right away.
    }

    void CheckIfWeaponShouldAttack()
    {
        if(Time.time > nextAttack && Time.timeScale > 0 && _transform.root.CompareTag(MCP_References._playerTag))
        {
            if(isAutomatic && !isBurstFireActive)
            {
                if (Input.GetButton(attackButtonName))
                {
                    Debug.Log("Full Auto");
                    AttemptAttack();
                }
            }

            else if (isAutomatic && isBurstFireActive)
            {
                if (Input.GetButtonDown(attackButtonName))
                {
                    Debug.Log("Burst Yo");
                    StartCoroutine(RunBurstFire());
                }
            }
            else if (!isAutomatic)
            {
                if (Input.GetButtonDown(attackButtonName))
                {
                    AttemptAttack();
                }
            }
        }
    }

    void AttemptAttack()
    {
        nextAttack = Time.time + attackRate;

        if (gun_Master.isGunLoaded)
        {
            Debug.Log("Shooting");
            gun_Master.CallEventPlayerInput();
        }
        else
        {
            gun_Master.CallEventPlayerInput(); 
            //TODO: Out of ammo clicking noise. 
            //TODO: Out of ammo indicatior.
        }
    }

    void CheckForReloadRequest()
    {
        if(Input.GetButtonDown(reloadButtonName) && Time.timeScale > 0 && _transform.root.CompareTag(MCP_References._playerTag))
        {
            Debug.Log("RELOADING!!!!!!");
            gun_Master.CallEventRequestReload();
        }
    }

    void CheckForBurstFireToggle()
    {
        if (Input.GetButtonDown(burstFireButtonName) && Time.timeScale > 0 && _transform.root.CompareTag(MCP_References._playerTag))
        {
            Debug.Log("Burst Fire Mode Toggled");
            isBurstFireActive = !isBurstFireActive;
            gun_Master.CallEventToggleBurstFire();
        }
    }

    IEnumerator RunBurstFire()
    {
        AttemptAttack();
        yield return new WaitForSeconds(attackRate);
        AttemptAttack();
        yield return new WaitForSeconds(attackRate);
        AttemptAttack();
    }
}
