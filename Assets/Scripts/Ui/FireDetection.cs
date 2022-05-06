using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDetection : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<AudioSource>().Play();
        }
       

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<AudioSource>().Stop();
        }
      
    }


}
