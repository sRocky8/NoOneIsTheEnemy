﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Public Variables
    public float maxDistanceDelta;

    //Private Variables
    [SerializeField]private GameObject explosion;
    [SerializeField]private GameObject player;

    void Start()
    {
        transform.LookAt(player.transform);
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, maxDistanceDelta);
    }

    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
