using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField] protected float _hp;
    [SerializeField] protected float _patrolSpeed;
    [SerializeField] protected float _followSpeed;
    [SerializeField] protected float _takenDmg;

    [Header("Detection")]
    [SerializeField] protected Transform[] _wayPoints;
    protected Transform _player;
    protected int _currentWaypoint;
    [SerializeField] protected LayerMask _playerLayer;
    [SerializeField] protected float _detectionRange;

    [Header("Attack Range")]
    [SerializeField] protected float _attackRange;
    [SerializeField] protected float _attackSpeed;

    protected Rigidbody2D _rb;
    protected Animator _animator;

    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if(_player != null)
        {
            Debug.Log("Player Iniciado");
        }
    }
}
