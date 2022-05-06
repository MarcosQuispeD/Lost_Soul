using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public static LifeSystem instance;
    public List<GameObject> lifes;
    public GameObject addLife;
    public int life;
    public bool dead;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        SetLife();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            Time.timeScale = 0;
            GameManagerController.instance.ChangeScene(4);
        }
    }

    public void AddLife()
    {
        for (int i = 0; i < lifes.Count; i++)
        {

            if (lifes[i].GetComponent<Image>().enabled == false)
            {
                lifes[i].GetComponent<Image>().enabled = true;
                life++;
                return;
            }
        }
        lifes.Add(addLife);
        lifes[lifes.Count - 1].GetComponent<Image>().enabled = true;
        life++;
    }

    public void TakeDamage(int damage)
    {
        if (life >= 1)
        {
            life -= damage;
            if (damage > 1)
            {
                var count = 0;
                for (int i = 1; i <= lifes.Count; i++)
                {
                    if (lifes[lifes.Count - i] != null)
                    {
                        count++;
                        lifes[lifes.Count - i].gameObject.GetComponent<Image>().enabled = false;
                        //Destroy(lifes[lifes.Length-i].gameObject);
                    }
                    if (count == damage)
                    {
                        break;
                    }
                   
                }
            }
            else
            {
                lifes[life].gameObject.GetComponent<Image>().enabled = false;
                //Destroy(lifes[life].gameObject);
            }
          
            if (life < 1)
            {
                dead = true;
            }
        }
    }

    public void SetData()
    {
        if (DataManager.instance != null)
        {
            DataManager.instance.SetSaveLife(life);
        }
      
    }

    private void SetLife()
    {
        if (DataManager.instance == null)
        {
            life = lifes.Count;
            return;
        }
        if (!DataManager.instance.isInnitGame)
        {
            life = PlayerPrefs.GetInt("countLife", life);
            for (int i = 0; i < life; i++)
            {
                lifes[i].gameObject.GetComponent<Image>().enabled = true;
            }

            for (int i = life; i < lifes.Count; i++)
            {
                lifes[i].gameObject.GetComponent<Image>().enabled = false;
            }
            Debug.Log(life);
        }
        else
        {
            life = lifes.Count;
             
        }

    }
}
