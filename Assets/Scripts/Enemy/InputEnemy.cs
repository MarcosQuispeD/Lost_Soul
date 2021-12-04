using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEnemy : MonoBehaviour
{
    public Transform player;
    public float vertical { get { return directionPlayer.y; } }
    public float horizontal { get { return directionPlayer.x; } }
    public float distance { get { return directionPlayer.magnitude; } }
    public Vector2 directionPlayer;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        directionPlayer = player.position - transform.position;
    }
}
