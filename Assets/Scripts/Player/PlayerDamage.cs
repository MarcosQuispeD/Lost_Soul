using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private bool isInmune;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isInmune)
        {
            LifeSystem.instance.TakeDamage(collision.gameObject.GetComponentInParent<GhostEnemy>().damage);
            StartCoroutine(Inmune());
        }

        if (collision.gameObject.CompareTag("TrapDamage") && !isInmune)
        {
        
            LifeSystem.instance.TakeDamage(1);
            StartCoroutine(Inmune());
        }

        if (collision.gameObject.CompareTag("TrapDamageLarge") && !isInmune)
        {

            LifeSystem.instance.TakeDamage(1);
            StartCoroutine(Inmune());
        }
    }

    IEnumerator Inmune()
    {
        isInmune = true;
        AudioController.instance.PlayAudio(AudioController.instance.effectTrap);
        GetComponentInParent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(1.2f);
        GetComponentInParent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        isInmune = false;
    }
}
