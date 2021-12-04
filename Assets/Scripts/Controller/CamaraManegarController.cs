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
    }

    public void SetBoundConfinder(int id)
    {
        confiner.m_BoundingShape2D = collider[id].GetComponent<PolygonCollider2D>();
        if (id == 1)
        {
            Time.timeScale = 0;
            GameManagerController.instance.ChangeScene(3);
        }
    }
}
