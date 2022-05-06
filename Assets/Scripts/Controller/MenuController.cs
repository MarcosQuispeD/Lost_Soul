using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void StartGame()
    {
        if (DataManager.instance != null)
        {
            DataManager.instance.isInnitGame = true;
        }
        ChangeScene(2);
    }

    public void ReturnCheckGame()
    {
        if (DataManager.instance != null)
        {
            if (DataManager.instance.saveGame)
            {
                DataManager.instance.isInnitGame = false;
            }
        }
        ChangeScene(2);
    }

    public void ReturnMenu()
    {
        ChangeScene(0);
    }

    public void OptionsController()
    {
        ChangeScene(1);
    }

    public void Options()
    {
        ChangeScene(6);
    }

    public void CreditsController()
    {
        ChangeScene(5);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

}
