using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objToSpawn;
    public int numOfEnemies;
    private float spawnRadius = 5;
    private Vector3 spawnPos;
    private MCP_EventMaster eventMasterScript;

    void OnEnable()
    {
        SetInitRef();
        eventMasterScript._GE += SpawnObject;
    }

    void OnDisable()
    {
        eventMasterScript._GE -= SpawnObject;
    }

    void SpawnObject()
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
            spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
            Instantiate(objToSpawn, spawnPos, Quaternion.identity);
        }
    }

    void SetInitRef()
    {
        eventMasterScript = GameObject.Find("MasterControlProgram").GetComponent<MCP_EventMaster>();
    }
}
