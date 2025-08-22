using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] private string _sceneName;
    [SerializeField] private float _waitTime;
    
    [SerializeField] private GameObject _open;
    [SerializeField] private GameObject _close;

    public string doorID;

    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        _close.SetActive(true);
        _open.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            _close.SetActive(false);
            _open.SetActive(true);
            gameManager._fadeOnOff = true;
            StartCoroutine(WaitTime(_waitTime));
        }
    }



    private void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        gameManager.lastDoorId = doorID;
    }

    private IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
        GoToScene(_sceneName);
    }
}
