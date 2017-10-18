using System.Collections;
using UnityEngine;

public class Item_Sounds : MonoBehaviour {

    private Item_Master item_Master;
    public float defaultVol;
    public AudioClip throwSound;


    void OnEnable()
    {
        SetInitRef();
        item_Master.EventObjectThrow += PlayThrowSound;

    }

    void OnDisable()
    {
        item_Master.EventObjectThrow -= PlayThrowSound;
    }

    void SetInitRef()
    {
        item_Master = GetComponent<Item_Master>();
    }

    void PlayThrowSound()
    {
        if(throwSound !=null)
        {
            AudioSource.PlayClipAtPoint(throwSound, transform.position, defaultVol);
        }
    }
}
