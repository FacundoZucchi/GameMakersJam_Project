using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackMele : MonoBehaviour
{
    private Animator _Animator;
    public bool AttackCheck;

    void Start()
    {
        _Animator = GetComponent<Animator>();
    }


    void Update()
    {
        Attack1();
    }

    void Attack1()
    {
        _Animator.SetBool("AttackCheck", AttackCheck);
        if (Input.GetKey(KeyCode.Z))
        {

            AttackCheck = true;
        }
      
      
    }
    public void Attack1End()
    {
        AttackCheck = false;
    }
  
    void Attack2()
    {

    }

    void Attack3()
    {

    }
}
