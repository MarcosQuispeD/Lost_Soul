using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public static ShootPlayer instance;

    public List<Transform> bulletsPrefab = new List<Transform>();


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        GetComponent<PlayerWeapon>().OnShoot += ShootingPlayer;
    }

    void ShootingPlayer(object sender, PlayerWeapon.OnShottingEvent e)
    {
        Transform bull = Instantiate(bulletsPrefab[GetComponent<PlayerWeapon>().indexSelect], e.bullPosition, Quaternion.identity);
        Vector3 shotDir = (e.shootPosition - e.bullPosition).normalized;
        AudioController.instance.PlayAudio(AudioController.instance.effectShoot);
        bull.GetComponent<BulletController>().Setup(shotDir);
    }

}
