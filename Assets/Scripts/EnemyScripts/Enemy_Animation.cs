using System.Collections;
using UnityEngine;

public class Enemy_Animation : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private Animator _animator;

    void OnEnable()
    {
        SetInitRef();
        enemyMaster.EventEnemyDie += DisableAnimator;
        enemyMaster.EventEnemyWalking += SetAnimationToWalk;
        enemyMaster.EventEnemyReachedNavTarget += SetAnimationToIdle;
        enemyMaster.EventEnemyAttack += SetAnimationToAttack;
        enemyMaster.EventEnemyDeductHealth += SetAnimationToStruck;
    }

    void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableAnimator;
        enemyMaster.EventEnemyWalking -= SetAnimationToWalk;
        enemyMaster.EventEnemyReachedNavTarget -= SetAnimationToIdle;
        enemyMaster.EventEnemyAttack -= SetAnimationToAttack;
        enemyMaster.EventEnemyDeductHealth -= SetAnimationToStruck;
    }

    void SetInitRef()
    {
        enemyMaster = GetComponent<Enemy_Master>();

        if(GetComponent<Animator>() != null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    void SetAnimationToWalk()
    {
        if(_animator != null)
        {
            if (_animator.enabled)
            {
                _animator.SetBool("isPursuing", true);
            }
        }
    }

    void SetAnimationToIdle()
    {
        if (_animator != null)
        {
            if (_animator.enabled)
            {
                _animator.SetBool("isPursuing", false);
            }
        }
    }

    void SetAnimationToAttack()
    {
        if (_animator != null)
        {
            if (_animator.enabled)
            {
                _animator.SetTrigger("Attack");
            }
        }
    }

    void SetAnimationToStruck(int dummy)
    {
        if (_animator != null)
        {
            if (_animator.enabled)
            {
                _animator.SetTrigger("Struck");
            }
        }
    }

    void DisableAnimator()
    {
        if(_animator != null)
        {
            _animator.enabled = false;
        }
    }

}
