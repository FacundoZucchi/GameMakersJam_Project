using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public float _AxisX;
    public float _AxisY;
    public bool movementCheck;
    [SerializeField] float speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {


    }
    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        _AxisX = Input.GetAxisRaw("Horizontal");
        _AxisY = Input.GetAxisRaw("Vertical");
        Vector2 Move = new Vector3(_AxisX, _AxisY).normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + Move);
        if (_AxisX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (_AxisX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }



    }
}
