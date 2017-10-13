using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NadeExplosion : MonoBehaviour {

    private Collider[] hitColliders;
    private float destryTime = 7f;
    public float blastRadius;
    public float explosionPower;
    public LayerMask explosionLayers;

    private void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.contacts[0].point.ToString());
        ExplosionWork(col.contacts[0].point);
        Destroy(gameObject, 1);
    }

    void ExplosionWork(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius, explosionLayers);

        foreach (Collider hitCol in hitColliders)
        {
            if (hitCol.GetComponent<NavMeshAgent>() != null)
            {
                hitCol.GetComponent<NavMeshAgent>().enabled = false;
            }
            //Debug.Log(hitCol.gameObject.name);
            if(hitCol.GetComponent<Rigidbody>() != null)
            {
                hitCol.GetComponent<Rigidbody>().isKinematic = false;
                hitCol.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPoint, blastRadius, 1, ForceMode.Impulse);
            }

            if (hitCol.CompareTag("Enemy"))
            {
                Destroy(hitCol.gameObject, destryTime);
            }

        }
    }

}
