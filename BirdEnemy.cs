using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEnemy : MonoBehaviour
{
    public float speed;
    public GameObject player;

    private void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position,10f);
    }
}
