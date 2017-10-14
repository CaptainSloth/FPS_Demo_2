using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField]
    private float fireRate = 0.3f;
    private float nextFire;
    private RaycastHit hit;
    [SerializeField]
    private float range = 300;
    private Transform _transform;

    // Use this for initialization
    void Start()
    {
        SetInitRef();
    }

    // Update is called once per frame
    void Update()
    {
        CheckforInput();
    }

    void SetInitRef()
    {
        _transform = transform;
    }

    void CheckforInput()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Debug.DrawRay(_transform.TransformPoint(0, 0, 1), _transform.forward, Color.red, 3);
            if (Physics.Raycast(_transform.TransformPoint(0, 0, 1), _transform.forward, out hit, range))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy: " + hit.transform.name);
                }
                else
                {
                    Debug.Log("NOT AN EMENEMENY");
                }

            }
            nextFire = Time.time + fireRate;

        }
    }











}
