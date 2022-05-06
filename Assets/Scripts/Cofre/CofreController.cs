using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class CofreController : MonoBehaviour
{
    public Sprite itemBonus;
    public Transform shootBonus;
    public int index;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioController.instance.PlayAudio(AudioController.instance.effectCofre);
            ShootPlayer.instance.bulletsPrefab.Add(shootBonus);
            PlayerWeapon.instance.bulletTransformPosition[index].GetComponent<SpriteRenderer>().sprite = itemBonus;
            PlayerWeapon.instance.bulletTransformPosition[index].gameObject.GetComponentInChildren<Light2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

}
