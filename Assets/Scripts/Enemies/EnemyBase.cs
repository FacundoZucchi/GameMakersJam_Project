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
    [SerializeField] protected LayerMask _playerLayer;
    [SerializeField] protected float _detectionRange;

    private Rigidbody2D _rb; 

    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
}
