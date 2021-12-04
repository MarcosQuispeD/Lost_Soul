using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public static LifeSystem instance;
    public GameObject[] lifes;
    public GameObject addLife;
    public int life;
    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        life = lifes.Length;
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
        for (int i = 0; i < lifes.Length; i++)
        {

            if (lifes[i] == null)
            {
                lifes[i] = addLife;
                break;
            }

        }
    }


    public void TakeDamage(int damage)
    {
        if (life >= 1)
        {
            life -= damage;
            if (damage > 1)
            {
                var count = 0;
                for (int i = 1; i <= lifes.Length; i++)
                {
                    if (lifes[lifes.Length-i] != null)
                    {
                        count++;
                        Destroy(lifes[lifes.Length-i].gameObject);
                    }
                    if (count == damage)
                    {
                        break;
                    }
                   
                }
            }
            else
            {
                Destroy(lifes[life].gameObject);
            }
          
            if (life < 1)
            {
                dead = true;
            }
        }
    }
}
