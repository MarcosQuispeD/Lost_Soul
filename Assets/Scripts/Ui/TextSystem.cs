using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextSystem : MonoBehaviour
{

    public GameObject collectionItems;

    void Awake()
    {
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (collectionItems != null)
        {
            collectionItems.GetComponent<Text>().text = GameManagerController.instance?.bounds.ToString();
        }
     
    }

    public void ViewText(int id)
    {

        
    }
}


