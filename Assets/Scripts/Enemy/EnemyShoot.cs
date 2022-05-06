using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] Transform innit;
    [SerializeField] GameObject bullet;
    public float fireRate;
    bool isDamage;
    Animator anim;
    [SerializeField] GameObject light;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            light.SetActive(false);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            anim.SetBool("IsAttack", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isDamage)
        {
            anim.SetBool("IsAttack", true);
            light.SetActive(true);
            GetComponent<AudioSource>().Play();
            StartCoroutine(Attack());
        }
       
    }


    IEnumerator Attack()
    {
        isDamage = true;
        GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 0.5f, 1);
        Instantiate(bullet, innit.position, Quaternion.identity);
        
        yield return new WaitForSeconds(fireRate);
        isDamage = false;
    }
}
