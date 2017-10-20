using System.Collections;
using UnityEngine;

public class SpawnerProximity : MonoBehaviour {

    public GameObject objToSpawn;
    public int numToSpawn;
    public float prox;
    private float checkRate;
    private float nextCheck;
    private Transform _transform;
    private Transform _playerTransform;
    private Vector3 spawnPos;

    void Start()
    {
        SetInitRef();
    }

    void Update()
    {
        CheckDist();
    }

    void SetInitRef()
    {
        _transform = transform;
        _playerTransform = MCP_References._player.transform;
        checkRate = Random.Range(0.8f, 1.2f);
    }

    void CheckDist()
    {
        if(Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            if(Vector3.Distance(_transform.position, _playerTransform.position) < prox)
            {
                SpawnObj();
                this.enabled = false;
            }
        }
    }

    void SpawnObj()
    {
        for (int i = 0; i < numToSpawn; i++)
        {
            spawnPos = _transform.position + Random.insideUnitSphere * 5;
            Instantiate(objToSpawn, spawnPos, _transform.rotation);
        }
    }
}
