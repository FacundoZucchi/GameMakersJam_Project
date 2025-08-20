using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackMele : MonoBehaviour
{
    private Animator _Animator;
    public bool AttackCheck;
    int ComboStep = 0;
    float ComboDelay = 1f;
    float LastAttackTime;

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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ComboStep++;
            AttackCheck = true;
            if (Time.time - LastAttackTime > ComboDelay)
            {
                ComboStep = 0;
            }
            if (ComboStep == 2) Attack2();
            else if (ComboStep == 3) Attack3();        
        }
      
      
    }
  
    void Attack2()
    {
        _Animator.SetInteger("AttackCombo", 2);
    }

    void Attack3()
    {
        _Animator.SetInteger("AttackCombo", 3);
    }
    public void Attack1End()
    {
        AttackCheck = false;
    }
}
