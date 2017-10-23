using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gun_AmmoUI : MonoBehaviour {

    public InputField currentAmmoField;
    public InputField carriedAmmoField;
    private Gun_Master gun_Master;

    void OnEnable()
    {
        SetInitRef();
        gun_Master.EventAmmoChanged += UpdateAmmoUI;
    }

    void OnDisable()
    {
        gun_Master.EventAmmoChanged -= UpdateAmmoUI;
    }

    void SetInitRef()
    {
        gun_Master = GetComponent<Gun_Master>();
    }

    void UpdateAmmoUI(int currentAmmo, int carriedAmmo)
    {
        if(currentAmmoField != null)
        {
            currentAmmoField.text = currentAmmo.ToString();
        }

        if (carriedAmmoField != null)
        {
            carriedAmmoField.text = carriedAmmo.ToString();
        }
    }
}
