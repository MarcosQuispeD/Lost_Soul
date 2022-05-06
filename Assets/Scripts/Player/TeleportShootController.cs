using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportShootController : MonoBehaviour
{
    public static TeleportShootController instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Teleport(GameObject gameObject)
    {
        transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,0);
    }
}
