using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsController : MonoBehaviour
{
    private bool isOpenDoor;
    public int idDoor;
    public GameObject doorClose;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameManagerController.instance.keys.Count > 0 && !isOpenDoor)
            {
                OpenDoor();
            }
            else
            {
                PanelSystem.instance.OpenPanel(3);
            }
        }

    }

    private void OpenDoor()
    {
        if (GameManagerController.instance.OpenDoorForKey(idDoor))
        {
            CamaraManegarController.instance.SetBoundConfinder(idDoor);
            isOpenDoor = true;
            gameObject.SetActive(false);
            doorClose.SetActive(true);
        }
        else
        {
            PanelSystem.instance.OpenPanel(3);
        }
    }

}
