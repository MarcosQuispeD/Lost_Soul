using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public ParticleSystem particle;
    private Vector3 shootDir;
    public float hSliderValueR = 0.0F;
    public float hSliderValueG = 0.0F;
    public float hSliderValueB = 0.0F;
    public float hSliderValueA = 1.0F;
    public float moveSpeed;
    public void Setup(Vector3 shootDir)
    {
        this.shootDir = shootDir;
        Destroy(gameObject,0.8f);
    }


    // Update is called once per frame
    void Update()
    {
        var main = particle.main;
        main.startColor = new Color(hSliderValueR, hSliderValueG, hSliderValueB, hSliderValueA);
    }

    private void FixedUpdate()
    {
       
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TrapFire") && PlayerWeapon.instance.bulletTransformPosition.Count > 1 && PlayerWeapon.instance.indexSelect == 1)
        {
            FireTrap.instance.liveTrap--;
            FireTrap.instance.light.intensity = FireTrap.instance.light.intensity - 0.2f;
        }

        if (collision.gameObject.CompareTag("Collision"))
        {
            InstateParticle();
            DestoyComponent(gameObject);
        }

        if (collision.gameObject.CompareTag("CollisionMira"))
        {

            InstateParticle();
            if (PlayerWeapon.instance.indexSelect == 2 && !LookMousePlayer.instance.mira)
            {
                TeleportShootController.instance.Teleport(gameObject);
            }
            DestoyComponent(gameObject);
        }

        if (collision.gameObject.CompareTag("TrapDamage"))
        {
            InstateParticle();
            DestoyComponent(gameObject);
        }

        if (collision.gameObject.CompareTag("TrapDamageLarge"))
        {
            if (PlayerWeapon.instance.indexSelect != 2)
            {
                InstateParticle();
                DestoyComponent(gameObject);
            }
           
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            InstateParticle();
            GameManagerController.instance.bounds = GameManagerController.instance.bounds +1f;
            DestoyComponent(collision.attachedRigidbody.GetComponent<Enemy>().gameObject);
            DestoyComponent(gameObject);
        }
    }
    private void InstateParticle()
    {
        var main = particle.main;
        main.startColor = new Color(hSliderValueR, hSliderValueG, hSliderValueB, hSliderValueA);

        Instantiate(particle, gameObject.transform.position, Quaternion.identity);
    }


    private void DestoyComponent(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
