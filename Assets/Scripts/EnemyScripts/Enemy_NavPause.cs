using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_NavPause : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private NavMeshAgent _NavMeshAgent;
    private float pauseTime;

    void OnEnable()
    {
        SetInitRef();
        enemyMaster.EventEnemyDie += DisableThis;
        enemyMaster.EventEnemyDeductHealth += PauseNavMeshAgent;
    }

    void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableThis;
        enemyMaster.EventEnemyDeductHealth -= PauseNavMeshAgent;
    }

    void SetInitRef()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        if (GetComponent<NavMeshAgent>() != null)
        {
            _NavMeshAgent = GetComponent<NavMeshAgent>();
        }

    }

    void PauseNavMeshAgent(int dummy)
    {
        if(_NavMeshAgent != null)
        {
            if (_NavMeshAgent.enabled)
            {
                _NavMeshAgent.ResetPath();
                enemyMaster.isNavPaused = true;
                StartCoroutine(RestartNavMeshAgent());
            }
        }

    }

    IEnumerator RestartNavMeshAgent()
    {
        yield return new WaitForSeconds(pauseTime);
        enemyMaster.isNavPaused = false;
    }

    void DisableThis()
    {
        StopAllCoroutines();
    }

}
