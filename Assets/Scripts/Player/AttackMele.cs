using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackMele : MonoBehaviour
{
    private Animator _Animator;
    [SerializeField] int _ComboStep;
    public  bool _AttackCheck;
    [SerializeField] GameObject _Hitbox;
 

    void Start()
    {
        _Animator = GetComponent<Animator>();
        _Hitbox.SetActive(false);
        _AttackCheck = false;
      
    }


    void Update()
    {
        Combos();

    }




    private void Combos()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            
            _Animator.SetTrigger("" + _ComboStep);
            _Hitbox.SetActive(true);
            Invoke(nameof(DisableHitbox), 0.3f);
            _AttackCheck = true;

        }

    }


    public void Start_Combo()
    {

        if (_ComboStep < 3)
        {
            _ComboStep++;

        }
    }


    public void Finish_ani()
    {
        _ComboStep = 0;
        
      
    }

    void DisableHitbox()
    {
        _Hitbox.SetActive(false);
    }
    

    


}
