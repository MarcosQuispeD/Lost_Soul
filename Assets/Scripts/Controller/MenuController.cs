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
