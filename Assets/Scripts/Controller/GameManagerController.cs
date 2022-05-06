using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
    public static GameManagerController instance;
    public List<int> keys;
    public float bounds;

    void Awake()
    {
        Time.timeScale = 1;
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        keys = new List<int>();

        AudioController.instance.ConvertAudio(AudioController.instance.backgroundGame);
        GetBounds();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ChangeScene(int scene)
    {
        AudioController.instance.ConvertAudio(AudioController.instance.backGorundMenu);
        SceneManager.LoadScene(scene);
    }

    public void CollectionKeys(int key)
    {
        keys.Add(key);

    }

    public bool OpenDoorForKey(int idDoor)
    {
        for (int i = 0; i < keys.Count; i++)
        {
            if (keys[i] == idDoor)
            {

                return true;
            }
        }
        return false;
    }

    public void SetData()
    {
        if (DataManager.instance != null)
        {
            DataManager.instance.SetSaveKeys(keys.Count);
        }

    }

    public void SetDataBounds()
    {
        if (DataManager.instance != null)
        {
            DataManager.instance.SetSaveBound(bounds);
        }

    }


    private void GetBounds()
    {
        if (DataManager.instance == null)
        {
            return;
        }
        if (!DataManager.instance.isInnitGame)
        {
            bounds = PlayerPrefs.GetFloat("bounds", bounds);
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
