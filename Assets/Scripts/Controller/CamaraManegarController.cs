using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraManegarController : MonoBehaviour
{
    public static CamaraManegarController instance;
    private CinemachineConfiner confiner;
    public new List<GameObject> collider = new List<GameObject>();


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        confiner = GetComponent<CinemachineConfiner>();
        GetCamera();
    }

    public void SetData()
    {
        if (DataManager.instance != null)
        {
            DataManager.instance.SetSaveCamera(2);
        }

    }

    public void SetBoundConfinder(int id)
    {
        if (id <= 1)
        {
            confiner.m_BoundingShape2D = collider[id].GetComponent<PolygonCollider2D>();
            SetData();
        }
       
    }

    public void GetCamera()
    {
        if (DataManager.instance == null)
        {
            return;
        }
        if (!DataManager.instance.isInnitGame)
        {
            confiner.m_BoundingShape2D = collider[1].GetComponent<PolygonCollider2D>();
        }


    }
}
