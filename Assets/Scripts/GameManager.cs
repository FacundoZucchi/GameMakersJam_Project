using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Fade In Out Fx")]
    [SerializeField] private float _fadeSpeed;
    private Image _startPanel;
    public bool _fadeOnOff;
    private float _targetAlpha;
    private GameObject _PauseMenu;
    private bool _pause;

    [Header("Doors SetUp")]
    public string lastDoorId;

    [Header("Life & Heal")]
    [SerializeField] private float _deceaseSpeed;
    [SerializeField] private float _hp;
    private Slider _hpSliderBar;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        _startPanel = GameObject.FindGameObjectWithTag("FadeFx").GetComponent<Image>();
        _PauseMenu = GameObject.FindGameObjectWithTag("pause");
        _hpSliderBar = GameObject.FindGameObjectWithTag("hpSlider").GetComponent<Slider>();

        _fadeOnOff = false;
        _pause = false;
        _hp = 100f;
    }

    private void Update()
    {
        if(!_fadeOnOff)
        {
            _targetAlpha = 0;
        }

        else if(_fadeOnOff)
        {
            _targetAlpha = 1;
        }

        if(_targetAlpha <= 0.1)
        {
            _startPanel.raycastTarget = false;
        }

        else
        {
            _startPanel.raycastTarget = true;
        }
        Fade();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pause = !_pause;
        }

        Pause(_pause);

        HpSliderSets();
        DeceaseOverTime();
        
    }

    private void Fade()
    {
        Color color = _startPanel.color;
        color.a = Mathf.MoveTowards(color.a, _targetAlpha, _fadeSpeed * Time.deltaTime);
        _startPanel.color = color;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        var startFade = GameObject.FindGameObjectWithTag("FadeFx");
        if(startFade != null)
        {
            _fadeOnOff = false;
        }
    }

    private void Pause(bool pauseOnOff)
    {
        
        if(pauseOnOff)
        {
            _PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        else if(!pauseOnOff)
        {
            _PauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        
    }

    public void PauseOffBtn()
    {
        _pause = false;
        _PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitBtn()
    {
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void HpSliderSets()
    {
        _hpSliderBar.maxValue = 100f;
        _hpSliderBar.value = _hp;
    }

    private void DeceaseOverTime()
    {
        _hp -= _deceaseSpeed * Time.deltaTime;
    }
}
