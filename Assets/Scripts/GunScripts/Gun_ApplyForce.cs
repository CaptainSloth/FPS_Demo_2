using System.Collections;
using UnityEngine;

public class Gun_ApplyForce : MonoBehaviour {

    private Gun_Master gun_Master;
    private Transform _transform;
    public float forceToApply = 300;

    void OnEnable()
    {
        SetInitRef();
        gun_Master.EventShotDefault += ApplyForce;
    }

    void OnDisable()
    {
        gun_Master.EventShotDefault -= ApplyForce;
    }

    void SetInitRef()
    {
        gun_Master = GetComponent<Gun_Master>();
        _transform = transform;
    }

    void ApplyForce(Vector3 hitPos, Transform hitTransform)
    {
        if (hitTransform.GetComponent<Rigidbody>() !=null)
        {
            hitTransform.GetComponent<Rigidbody>().AddForce(_transform.forward * forceToApply, ForceMode.Impulse);
        }
    }

}
