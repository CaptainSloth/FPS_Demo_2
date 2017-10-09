using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objToSpawn;
    public int numOfEnemies;
    private float spawnRadius = 5;
    private Vector3 spawnPos;

	// Use this for initialization
	void Start () {
        SpawnObject();
	}
	
	//// Update is called once per frame
	//void Update () {
		
	//}

    void SpawnObject()
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
            spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
            Instantiate(objToSpawn, spawnPos, Quaternion.identity);
        }
    }
}
