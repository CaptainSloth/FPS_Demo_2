using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Player_AmmoBox : MonoBehaviour {

    private Player_Master player_Master;
    [System.Serializable]
    public class AmmoTypes
    {
        public string ammoName;
        public int ammoCurrentCarried;
        public int ammoMaxQuantity;

        public AmmoTypes(string aName, int aMaxQuantity, int aCurrentCarried)
        {
            ammoName = aName;
            ammoMaxQuantity = aMaxQuantity;
            ammoCurrentCarried = aCurrentCarried;
        }
    }

    public List<AmmoTypes> typesOfAmmunition = new List<AmmoTypes>();

    private void OnEnable()
    {
        SetInitRef();
        player_Master.EventPickedUpAmmo += PickedUpAmmo;
    }

    private void OnDisable()
    {
        player_Master.EventPickedUpAmmo -= PickedUpAmmo;
    }

    void SetInitRef()
    {
        player_Master = GetComponent<Player_Master>();
    }
   
    void PickedUpAmmo(string ammoName, int quantity)
    {
        for (int i = 0; i < typesOfAmmunition.Count; i++)
        {
            if(typesOfAmmunition[i].ammoName == ammoName)
            {
                typesOfAmmunition[i].ammoCurrentCarried += quantity;

                if(typesOfAmmunition[i].ammoCurrentCarried > typesOfAmmunition[i].ammoMaxQuantity)
                {
                    typesOfAmmunition[i].ammoCurrentCarried = typesOfAmmunition[i].ammoMaxQuantity;
                }

                player_Master.CallEventAmmoChanged();

                break;
            }
        }
    }

}
