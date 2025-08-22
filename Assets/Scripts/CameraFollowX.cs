using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollowX : MonoBehaviour
{
    public static CameraFollowX Instance;
    public Transform Player;
    [SerializeField] float  _SmoothSpeed =  0.125f;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
    }
    private void Start()
    {
        transform.position = new Vector3 (Player.position.x , transform.position.y , transform.position.z); 
    }

    private void LateUpdate()
    {
        Vector3 Playerpos = new Vector3(Player.position.x, transform.position.y, transform.position.z);
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, Playerpos, _SmoothSpeed);
        transform.position = SmoothedPosition;
    }
}
