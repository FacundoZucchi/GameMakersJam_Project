using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyBase
{
    public bool _playerInRange;

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
        _playerInRange = Physics2D.OverlapCircle(transform.position, _detectionRange, _playerLayer);

        switch (_currentState)
        {
            case enemyStates.Patrol:
                Patrol();
                break;
            case enemyStates.Follow:
                Follow();
                break;
            case enemyStates.Attack:
                break;
            case enemyStates.Death:
                break;
        }
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, _wayPoints[_currentWaypoint].position, _patrolSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, _wayPoints[_currentWaypoint].position) < 0.2f)
        {
            if(_currentWaypoint == 0)
            {
                _currentWaypoint++; 
            }

            else if(_currentWaypoint == 1)
            {
                _currentWaypoint--;
            }
        }

        if(_playerInRange)
        {
            _currentState = enemyStates.Follow;
        }
    }

    private void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _followSpeed * Time.deltaTime);

        if(!_playerInRange)
        {
            _currentState = enemyStates.Patrol;
        }
    }

    private void Attack()
    {

    }

    private void Death()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _detectionRange);
    }
}
