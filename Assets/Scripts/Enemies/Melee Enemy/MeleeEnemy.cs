using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyBase
{
    public bool test;

    private enemyStates _currentState;
    private enum enemyStates
    {
        Patrol, 
        Follow,
        Attack,
        Death
    }

    protected override void Start()
    {
        base.Start();
        _currentState = enemyStates.Patrol;
    }

    protected void Update()
    {
        test = EnemyDetection();

        switch (_currentState)
        {
            case enemyStates.Patrol:
                break;
            case enemyStates.Follow:
                break;
            case enemyStates.Attack:
                break;
            case enemyStates.Death:
                break;
        }
    }

    private void Patrol()
    {
     
    }

    private void Follow()
    {

    }

    private void Attack()
    {

    }

    private void Death()
    {

    }

    public bool EnemyDetection()
    {
        return Physics2D.OverlapCircle(transform.position, _detectionRange, _playerLayer);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _detectionRange);
    }
}
