using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class CofreController : MonoBehaviour
{
    public Sprite itemBonus;
    public Transform shootBonus;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioController.instance.PlayAudio(AudioController.instance.effectCofre);
            PanelSystem.instance.OpenPanel(2);
            ShootPlayer.instance.bulletsPrefab.Add(shootBonus);
            PlayerWeapon.instance.bulletTransformPosition[1].GetComponent<SpriteRenderer>().sprite = itemBonus;
            PlayerWeapon.instance.bulletTransformPosition[1].gameObject.GetComponentInChildren<Light2D>().enabled = true;
            Destroy(gameObject);
        }
    }

}
