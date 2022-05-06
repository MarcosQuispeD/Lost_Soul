using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject panelPause;
    public bool isInPause;
    public static PauseController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isInPause = true;
            OptionsPanel();
        }
    }


    public void OptionsPanel()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
    }

    public void Return()
    {
        isInPause = false;
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }

    public void GoMenu()
    {
        Time.timeScale = 1;
        GameManagerController.instance.ChangeScene(0);
    }

    public void QuitGame()
    {
        GameManagerController.instance.QuitGame();
    }
}
