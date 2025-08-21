using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamesAnimControl : MonoBehaviour
{
    private GameManager gameManager;

    private Animator animator;

    private Image _fadePanel;

    private bool _canDoAnim;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();       

        _fadePanel = GameObject.FindGameObjectWithTag("fadePanel").GetComponent<Image>();
    }

    private void Update()
    {
        animator.SetBool("canDoAnim", _canDoAnim);
        startAnim();
    }

    private void startAnim()
    {
        if(_fadePanel.fillAmount <= 0.1)
        {
            _canDoAnim = true;
        }

        else if(_fadePanel.fillAmount >=0.9)
        {
            _canDoAnim = false;
        }
    }


}
