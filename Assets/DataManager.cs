using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public static DataManager instance;
    public bool isInnitGame;
    public Sprite itemBonus;
    public Transform shootBonus;
    public bool saveGame;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSaveCamera(int id)
    {
        PlayerPrefs.SetInt("counfinder", id);
    }

    public void SetSaveLife(int life)
    {
        PlayerPrefs.SetInt("countLife", life);
    }

    public void SetSaveKeys(int count)
    {
        PlayerPrefs.SetInt("keys", count);
    }

    public void SetSaveShoot(int count)
    {
        PlayerPrefs.SetInt("countShoot", count);
    }

    public void SetSavePosition()
    {
        PlayerPrefs.SetInt("position", 2);
    }

    public void SetSaveBound(float bounds)
    {
        PlayerPrefs.SetFloat("bounds",bounds);
    }
}
