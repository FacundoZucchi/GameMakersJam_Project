using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackMele : MonoBehaviour
{
    private Animator _Animator;
    [SerializeField] int _ComboStep;
    [SerializeField] bool _AttackCheck;
    [SerializeField] GameObject _Hitbox;

    void Start()
    {
        _Animator = GetComponent<Animator>();
    }


    void Update()
    {
        Combos();
    }




    private void Combos()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !_AttackCheck)
        {
            _AttackCheck = true;
            _Animator.SetTrigger("" + _ComboStep);
            _Hitbox.SetActive(true);
            Invoke(nameof(DisableHitbox), 0.3f);
             
        }

    }


    public void Start_Combo()
    {
        _AttackCheck = false;
        if (_ComboStep < 3)
        {
            _ComboStep++;
        }
    }


    public void Finish_ani()
    {
        _AttackCheck = false;
        _ComboStep = 0;
    }

    void DisableHitbox()
    {
        _Hitbox.SetActive(false);
    }



}
