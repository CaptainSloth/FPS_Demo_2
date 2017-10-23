using System.Collections;
using UnityEngine;

public class Gun_ApplyDMG : MonoBehaviour {

    private Gun_Master gun_Master;
    public int damage = 10;

    void OnEnable()
    {
        SetInitRef();
        gun_Master.EventShotEnemy += ApplyDMG;
    }

    void OnDisable()
    {
        gun_Master.EventShotEnemy -= ApplyDMG;
    }

    void SetInitRef()
    {
        gun_Master = GetComponent<Gun_Master>();
    }

    void ApplyDMG(Vector3 hitPos, Transform hitTransform)
    {
        if(hitTransform.GetComponent<Enemy_TakeDMG>() != null)
        {
            hitTransform.GetComponent<Enemy_TakeDMG>().ProcessDMG(damage);
        }
    }

}
