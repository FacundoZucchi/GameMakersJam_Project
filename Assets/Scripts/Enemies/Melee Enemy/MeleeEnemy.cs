using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyBase
{
    private bool _playerInRange;
    private bool _inAttackRange;

    private bool _playerAttacked;

    public bool _lookingRight;

    [SerializeField] private float _attackCD;

    [SerializeField] private enemyStates _currentState;
    private enum enemyStates
    {
        Patrol, 
        Follow,
        Attack,
        AttackCooldown,
        Hitted,
        Death
    }

    protected override void Start()
    {
        base.Start();
        _currentState = enemyStates.Patrol;
        _playerAttacked = false;
    }

    protected void Update()
    {
        _playerInRange = Physics2D.OverlapCircle(transform.position, _detectionRange, _playerLayer);
        _inAttackRange = Physics2D.OverlapCircle(transform.position, _attackRange, _playerLayer);

        switch (_currentState)
        {
            case enemyStates.Patrol:
                Patrol();
                break;
            case enemyStates.Follow:
                Follow();
                break;
            case enemyStates.Attack:
                Attack();
                break;
            case enemyStates.AttackCooldown:
                AttackCooldown();
                break;
            case enemyStates.Death:
                break;
        }
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, _wayPoints[_currentWaypoint].position, _patrolSpeed * Time.deltaTime);

        LookRotation(_wayPoints[_currentWaypoint].position);

        if (Vector2.Distance(transform.position, _wayPoints[_currentWaypoint].position) < 0.2f)
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

        LookRotation(_player.transform.position);

        if (!_playerInRange)
        {
            _currentState = enemyStates.Patrol;
        }

        if(_inAttackRange && !_playerAttacked)
        {
            _currentState = enemyStates.Attack;
        }
    }

    private void Attack()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _attackSpeed * Time.deltaTime);

        Debug.Log("se ataco al jugador");
        _playerAttacked = true;
        
        _currentState = enemyStates.AttackCooldown;

        return;
    }

    private void AttackCooldown()
    {
        StartCoroutine(Cooldown());
    }

    private void Hitted()
    {

    }

    private void Death()
    {

    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_attackCD);
        _playerAttacked = false;

        if(_inAttackRange)
        {
            _currentState = enemyStates.Attack;
        }

        else if (_playerInRange)
        {
            _currentState = enemyStates.Follow;
        }

        else
        {
            _currentState = enemyStates.Patrol;
        }
    }

    private void LookRotation(Vector3 objective)
    {
        if(objective.x < transform.position.x && !_lookingRight)
        {
            Turn();
        }

        else if(objective.x > transform.position.x && _lookingRight)
        {
            Turn();
        }
    }

    private void Turn()
    {
        _lookingRight = !_lookingRight;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}
