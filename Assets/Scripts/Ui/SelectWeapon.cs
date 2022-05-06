using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWeapon : MonoBehaviour
{

    public List<Sprite> image;
    public GameObject sprite;

    // Update is called once per frame
    void Update()
    {
        if (sprite != null)
        {
            sprite.GetComponent<Image>().sprite = image[PlayerWeapon.instance != null ? PlayerWeapon.instance.indexSelect:0];
        }
      
    }
}
