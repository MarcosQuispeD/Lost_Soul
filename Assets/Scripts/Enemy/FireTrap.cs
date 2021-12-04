using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class FireTrap : MonoBehaviour
{
    public static FireTrap instance;

    public new Light2D light;
    public int damage;
    public int liveTrap;
    private bool isInmune;


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isInmune)
        {
            AudioController.instance.PlayAudio(AudioController.instance.effectTrap);
            PanelSystem.instance.OpenPanel(1);
            LifeSystem.instance.TakeDamage(damage);
            StartCoroutine(Inmune(collision));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (liveTrap <= 0)
        {
            PlayerWeapon.instance.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            Destroy(gameObject);
        }
    }

    IEnumerator Inmune(Collision2D collision)
    {
        isInmune = true;
        collision.gameObject.GetComponentInParent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(1.5f);
        isInmune = false;
    }
}
