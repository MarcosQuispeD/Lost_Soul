using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public AudioClip backGorundMenu,backgroundGame;
    public AudioSource effectCofre,effectShoot,effectTrap;

    private void Awake()
    {
     
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        var audio = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            audio.clip = backGorundMenu;
        }
        else
        {
            audio.clip = backgroundGame;
        }
       
        PlayAudio(audio);
    }

    public void ConvertAudio(AudioClip clip)
    {
        var audio = GetComponent<AudioSource>();
        audio.clip = clip;
        PlayAudio(audio);
    }

    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }

}
