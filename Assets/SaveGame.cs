using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{

    public bool saveGame;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (DataManager.instance != null)
            {
                DataManager.instance.saveGame = true;
            }
            LifeSystem.instance.SetData();
            PlayerWeapon.instance.SetData();
            GameManagerController.instance.SetDataBounds();

           

        }
    }


}
