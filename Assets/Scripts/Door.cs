using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] private string _sceneName;
    [SerializeField] private float _waitTime;

    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            gameManager._fadeOnOff = true;
            StartCoroutine(WaitTime(_waitTime));
        }
    }

    private void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
        GoToScene(_sceneName);
    }
}
