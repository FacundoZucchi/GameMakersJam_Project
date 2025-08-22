using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRePosition : MonoBehaviour
{
    [SerializeField] private string doorId;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();;
    }

    private void Start()
    {
        if(gameManager.lastDoorId == doorId)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = transform.position;
        }
    }
}
