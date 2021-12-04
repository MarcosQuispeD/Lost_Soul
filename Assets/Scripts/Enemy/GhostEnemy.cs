using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : Enemy
{
    private InputEnemy inputEnemy;
    private bool dead;
    private bool attack;

    public float distanceDetecction;
    public float distanceAttack;

    // Start is called before the first frame update
    void Start()
    {
        inputEnemy = GetComponentInChildren<InputEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void FlipEnemy()
    {
        if (inputEnemy.horizontal > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FlipEnemy();
            transform.position += (Vector3)inputEnemy.directionPlayer * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = transform.position;
            GetComponent<AudioSource>().Stop();
        }
    }
}
