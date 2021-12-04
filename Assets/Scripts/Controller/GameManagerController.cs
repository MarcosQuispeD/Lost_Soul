using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
    public static GameManagerController instance;
    public List<int> keys;


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
        PanelSystem.instance.OpenPanel(0);

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
}
