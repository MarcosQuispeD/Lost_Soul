using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement instance;
    Rigidbody2D rb;
    Vector2 movement;
    public float speed;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<LifeSystem>().dead)
        {
            movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

       
    }

    private void FixedUpdate()
    {
        if (!GetComponent<LifeSystem>().dead)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
      
    }
}
