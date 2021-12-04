using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    // Update is called once per frame
    void Update()
    {
        ChangeBullet();
        Direction();
        Shooting();
    }

    void ChangeBullet()
    {

        if (Input.GetKey(KeyCode.Q))
        {
            indexSelect = 0; 
        }
        if (Input.GetKey(KeyCode.E) && ShootPlayer.instance.bulletsPrefab.Count > 1)
        {
            indexSelect = 1;
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
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            OnShoot?.Invoke(this, new OnShottingEvent
            {
                bullPosition = bulletTransformPosition[indexSelect].position,
                shootPosition = mousePosition
            });
        }
    }
}
