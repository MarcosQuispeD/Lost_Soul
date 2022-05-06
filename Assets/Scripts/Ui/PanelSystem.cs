using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSystem : MonoBehaviour
{
    public static PanelSystem instance;
    public float time = 6f;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (GetComponent<Image>().enabled)
        //{
        //    time -= Time.deltaTime;
        //}

        //if (time <= 0)
        //{
        //    TextSystem.instance.gameObject.GetComponent<Text>().text = "";
        //    GetComponent<Image>().enabled = false;
        //    time = 6f;
        //}
       
    }


    public void OpenPanel(int id)
    {
        //time = 6f;
        //GetComponent<Image>().enabled = true;
        //TextSystem.instance.ViewText(id);

    }
}
