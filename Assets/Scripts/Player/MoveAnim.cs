using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnim : MonoBehaviour
{
    private Player _player;
    private Animator _Animator;
    void Start()
    {
        _player = GetComponent<Player>();
        _Animator = GetComponent<Animator>();
        _player.movementCheck = false;

    }

    void Update()
    {
        _Animator.SetBool("MovementCheck", _player.movementCheck);
        if (_player._AxisX != 0 || _player._AxisY != 0)
        {
            _player.movementCheck = true;
        }
        else
        {
            _player.movementCheck = false;
        }
    }
}
