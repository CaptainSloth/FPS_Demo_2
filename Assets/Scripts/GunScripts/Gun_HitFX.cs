using System.Collections;
using UnityEngine;

public class Gun_HitFX : MonoBehaviour {

    private Gun_Master gun_Master;
    public GameObject defaultHitFX;
    public GameObject enemyHitFX;

    void OnEnable()
    {
        SetInitRef();
        gun_Master.EventShotDefault += SpawnDefaultHitFX;
        gun_Master.EventShotEnemy += SpawnEnemyHitFX;
    }

    void OnDisable()
    {
        gun_Master.EventShotDefault -= SpawnDefaultHitFX;
        gun_Master.EventShotEnemy -= SpawnEnemyHitFX;
    }

    void SetInitRef()
    {
        gun_Master = GetComponent<Gun_Master>();
    }

    void SpawnDefaultHitFX(Vector3 hitPos, Transform hitTransform)
    {
        if(defaultHitFX != null)
        {
            Instantiate(defaultHitFX, hitPos, Quaternion.identity);
        }
    }

    void SpawnEnemyHitFX(Vector3 hitPos, Transform hitTransform)
    {
        if (enemyHitFX != null)
        {
            Instantiate(enemyHitFX, hitPos, Quaternion.identity);
        }
    }
}
