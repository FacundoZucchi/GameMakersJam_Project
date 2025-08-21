using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private GameObject _mainMenu;
    private GameObject _optionMenu;
    private GameObject _creditsMenu;
    private Image _fadePanel;
    public bool _fadeOnOff;
    [SerializeField] private float _fadeSpeed;
    private float _targetFill;

    [SerializeField] private string _firstLevel;
    [SerializeField] private float _playWaitTime;

    [SerializeField] private float _optionsWaitTime;

    [SerializeField] private float _backWaitTime;

    private void Awake()
    {
        _mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        _optionMenu = GameObject.FindGameObjectWithTag("OptionsMenu");
        _creditsMenu = GameObject.FindGameObjectWithTag("CreditsMenu");
        _fadePanel = GameObject.FindGameObjectWithTag("fadePanel").GetComponent<Image>();
    }

    private void Start()
    {
        _mainMenu.SetActive(true);
        _optionMenu.SetActive(false);
        _creditsMenu.SetActive(false);
        _fadeOnOff = true;
    }

    private void Update()
    {
        FadeOnOff();
    }

    public void PlayBTN()
    {
        StartCoroutine(waitBeforeChangeScene());
    }

    private IEnumerator waitBeforeChangeScene()
    {
        _fadeOnOff = false;
        yield return new WaitForSeconds(_playWaitTime);
        SceneManager.LoadScene(_firstLevel);

    }

    public void OptionsBTN()
    {
        StartCoroutine(FadeOptions());
    }

    private IEnumerator FadeOptions()
    {
        _fadeOnOff = false;
        yield return new WaitForSeconds(_optionsWaitTime);
        _mainMenu.SetActive(false);
        _optionMenu.SetActive(true);
        _fadeOnOff = true;
    }

    public void CreditsBTN()
    {
        StartCoroutine(FadeCredits());
    }

    private IEnumerator FadeCredits()
    {
        _fadeOnOff = false;
        yield return new WaitForSeconds(_optionsWaitTime);
        _mainMenu.SetActive(false);
        _creditsMenu.SetActive(true);
        _fadeOnOff = true;
    }

    public void BackBTNOptions()
    {
        StartCoroutine(FadeBackOptions());
    }

    private IEnumerator FadeBackOptions()
    {
        _fadeOnOff = false;
        yield return new WaitForSeconds(_backWaitTime);
        _mainMenu.SetActive(true);
        _optionMenu.SetActive(false);
        _fadeOnOff = true;
    }

    public void BackBTNCredits()
    {
        StartCoroutine(FadeBackCredits());
    }

    private IEnumerator FadeBackCredits()
    {
        _fadeOnOff = false;
        yield return new WaitForSeconds(_backWaitTime);
        _mainMenu.SetActive(true);
        _creditsMenu.SetActive(false);
        _fadeOnOff = true;
    }
    

    public void ExitBTN()
    {
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void FadeOnOff()
    {
        if(_fadeOnOff)
        {
            _fadePanel.fillAmount -= _fadeSpeed * Time.deltaTime;
        }

        else if(!_fadeOnOff)
        {
            _fadePanel.fillAmount += _fadeSpeed * Time.deltaTime;
        }
    }
}
