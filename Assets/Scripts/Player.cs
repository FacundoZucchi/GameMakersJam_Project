using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float _AxisX;
    [SerializeField] float speed;
    private SpriteRenderer _SpriteRenderer;
    private Animator _Animator;
    bool movementCheck; 
    void Start()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        _Animator = GetComponent<Animator>();
    }


    void Update()
    {
        Movement();
        _Animator.SetBool("MovementCheck" ,  movementCheck);
    }


    void Movement()
    {
        _AxisX = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * _AxisX * speed * Time.deltaTime);
        if (_AxisX < 0)
        {

            _SpriteRenderer.flipX = true;
        }
        else if (_AxisX > 0)
        {
            
            _SpriteRenderer.flipX = false;
        }
        if (_AxisX != 0)
        {
            movementCheck = true;
        }else
        {
            movementCheck = false;
        }
    }
}
