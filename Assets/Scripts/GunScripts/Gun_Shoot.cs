using System.Collections;
using UnityEngine;

public class Gun_Shoot : MonoBehaviour {

    private Gun_Master gun_Master;
    private Transform _transform;
    private Transform camTransform;
    private RaycastHit hit;
    public float range = 400;
    private float offsetFactor = 7;
    private Vector3 startPos;

    void OnEnable()
    {
        SetInitRef();
        gun_Master.EventPlayerInput += OpenFire;
        gun_Master.EventSpeedCaptured += SetStartOfShootingPos;

    }

    void OnDisable()
    {
        gun_Master.EventPlayerInput -= OpenFire;
        gun_Master.EventSpeedCaptured -= SetStartOfShootingPos;
    }

    void SetInitRef()
    {
        gun_Master = GetComponent<Gun_Master>();
        _transform = transform;
        camTransform = _transform.parent;
    }

    void OpenFire()
    {
        // Debug.Log("FIREASKLDFJA");
        if(Physics.Raycast(camTransform.TransformPoint(startPos), camTransform.forward, out hit, range))
        {
            gun_Master.CallEventShotDefault(hit.point, hit.transform);
            if (hit.transform.CompareTag(MCP_References._enemyTag))
            {
                Debug.Log("Hit Enemy");
                gun_Master.CallEventShotEnemy(hit.point, hit.transform);
            }
        }
    }

    void SetStartOfShootingPos(float playerSpeed)
    {
        float offset = playerSpeed / offsetFactor;
        startPos = new Vector3(Random.Range(-offset, offset), Random.Range(-offset, offset), 1);
    }
}
