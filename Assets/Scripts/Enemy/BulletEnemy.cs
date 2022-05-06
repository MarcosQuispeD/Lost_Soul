using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    GameObject player;
    Vector2 direction;
    bool firstContact;

    public ParticleSystem particle;
    public float hSliderValueR = 0.0F;
    public float hSliderValueG = 0.0F;
    public float hSliderValueB = 0.0F;
    public float hSliderValueA = 1.0F;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        direction = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(direction.x,direction.y);
        firstContact = false;
        Destroy(gameObject,2f);
    }

    private void Update()
    {
        var main = particle.main;
        main.startColor = new Color(hSliderValueR, hSliderValueG, hSliderValueB, hSliderValueA);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            InstateParticle();
            Destroy(gameObject,0.1f);
        }

        if (collision.gameObject.CompareTag("Collision") && !firstContact)
        {
            firstContact = true;
        }
        else if (collision.gameObject.CompareTag("Collision") && firstContact)
        {
            InstateParticle();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("TrapDamage"))
        {
            InstateParticle();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("TrapDamageLarge"))
        {
            InstateParticle();
            Destroy(gameObject);
        }
    }

    private void InstateParticle()
    {
        var main = particle.main;
        main.startColor = new Color(hSliderValueR, hSliderValueG, hSliderValueB, hSliderValueA);

        Instantiate(particle, gameObject.transform.position, Quaternion.identity);
    }
}
