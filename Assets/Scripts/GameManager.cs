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

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        _startPanel = GameObject.FindGameObjectWithTag("FadeFx").GetComponent<Image>();

        _fadeOnOff = false;
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
        Fade();
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
        var spawn = GameObject.FindGameObjectWithTag("PlayerSpawn").GetComponent<Transform>();
        var player = GameObject.FindGameObjectWithTag("Player");

        if(spawn != null && player != null)
        {
            player.transform.position = spawn.transform.position;   
        }

        var startFade = GameObject.FindGameObjectWithTag("FadeFx");
        if(startFade != null)
        {
            _fadeOnOff = false;
        }
    }
}
