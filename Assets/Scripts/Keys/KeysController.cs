using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysController : MonoBehaviour
{
    public int key;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioController.instance.PlayAudio(AudioController.instance.effectCofre);
            GameManagerController.instance.CollectionKeys(key);
            Destroy(gameObject);
        }
    }
}
