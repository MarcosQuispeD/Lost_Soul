using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class PlayerWeapon : MonoBehaviour
{
    public static PlayerWeapon instance;
    public event EventHandler<OnShottingEvent> OnShoot;

    public class OnShottingEvent : EventArgs
    {
        public Vector3 bullPosition;
        public Vector3 shootPosition;
    }

    public new Transform transform;
    public List<Transform> bulletTransformPosition = new List<Transform>();
    public int indexSelect;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        indexSelect = 0;
        GetWeapon();
        GetPosition();

    }

    // Update is called once per frame
    void Update()
    {
       
        Direction();
        Shooting();
    }
    private void FixedUpdate()
    {
        ChangeBullet();
    }

    void ChangeBullet()
    {

        if (Input.GetKeyDown(KeyCode.Q) && ShootPlayer.instance.bulletsPrefab.Count > 1)
        {
            if (indexSelect == 0)
            {
                indexSelect = ShootPlayer.instance.bulletsPrefab.Count-1;
            }
            else
            {
                if (indexSelect <= ShootPlayer.instance.bulletsPrefab.Count)
                {
                    indexSelect--;
                }
            }

          
        }
        if (Input.GetKeyDown(KeyCode.E) && ShootPlayer.instance.bulletsPrefab.Count > 1)
        {
            indexSelect++;
            if (indexSelect >= ShootPlayer.instance.bulletsPrefab.Count)
            {
                indexSelect = 0;
            }
        }


    }

    void Direction()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 direction = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0, 0, angle);

     
    }

    void Shooting()
    {
        if (Input.GetButtonDown("Fire1") && !PauseController.instance.isInPause)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            OnShoot?.Invoke(this, new OnShottingEvent
            {
                bullPosition = bulletTransformPosition[indexSelect].position,
                shootPosition = mousePosition
            });
        }
    }


    public void SetData()
    {
        if (DataManager.instance != null)
        {
            DataManager.instance.SetSaveShoot(bulletTransformPosition.Count);
            DataManager.instance.SetSavePosition();
        }
      
    }


    public void GetWeapon()
    {
        if (DataManager.instance == null)
        {
            return;
        }
        if (!DataManager.instance.isInnitGame)
        {
            var position = FindObjectOfType<SaveGame>().gameObject;
            GetComponentsInParent<Transform>()[0].position= new Vector3(position.transform.position.x, position.transform.position.y, 0);
        }
       
        
    }

    public void GetPosition()
    {
        if (DataManager.instance == null)
        {
            return;
        }
        if (!DataManager.instance.isInnitGame)
        {
            ShootPlayer.instance.bulletsPrefab.Add(DataManager.instance.shootBonus);
            bulletTransformPosition[PlayerPrefs.GetInt("countShoot") - ShootPlayer.instance.bulletsPrefab.Count].GetComponent<SpriteRenderer>().sprite = DataManager.instance.itemBonus;
            bulletTransformPosition[PlayerPrefs.GetInt("countShoot") - ShootPlayer.instance.bulletsPrefab.Count].gameObject.GetComponentInChildren<Light2D>().enabled = true;
        }
    }
}
