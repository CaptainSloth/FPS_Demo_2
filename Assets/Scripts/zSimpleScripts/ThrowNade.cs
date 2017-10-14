using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowNade : MonoBehaviour {

    public GameObject nadePrefab;
    private Transform _transform;
    public float propulsionForce;

	void Start ()
    {
        SetInitRef();
	}
	
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            spawnNade();
        }
	}

    void SetInitRef()
    {
        _transform = transform;
    }

    //Instantiate
    void spawnNade()
    {
        GameObject go = (GameObject) Instantiate(nadePrefab, _transform.TransformPoint(0, 0, 0.5f), _transform.rotation);
        go.GetComponent<Rigidbody>().AddForce(_transform.forward * propulsionForce, ForceMode.Impulse);
        Destroy(go, 10);
    }
}
