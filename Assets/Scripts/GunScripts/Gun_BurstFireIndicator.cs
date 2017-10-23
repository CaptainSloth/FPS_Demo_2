using System.Collections;
using UnityEngine;

public class Gun_BurstFireIndicator : MonoBehaviour {

    private Gun_Master gun_Master;
    public GameObject burstFireIndicator;
    
    void OnEnable()
    {
        SetInitRef();
        gun_Master.EventToggleBurstFire += ToggleIndicator;
    }

    void OnDisable()
    {
        gun_Master.EventToggleBurstFire -= ToggleIndicator;
    }

    void SetInitRef()
    {
        gun_Master = GetComponent<Gun_Master>();
    }

    void ToggleIndicator () 
	{
		if(burstFireIndicator != null)
        {
            burstFireIndicator.SetActive(!burstFireIndicator.activeSelf);
        }
	}
}
