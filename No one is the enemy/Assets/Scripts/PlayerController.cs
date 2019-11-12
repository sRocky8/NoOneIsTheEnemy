using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public Variables
    public float degreesPerSecond;

    //Private Variables
    private GameObject player;
    private int badNumbersLayer = 1 << 8;
    private int onesLayer = 1 << 9;

    void Start()
    {
        player = gameObject;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.Rotate(-Vector3.up, degreesPerSecond, Space.World);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.Rotate(Vector3.up, degreesPerSecond, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hitNumber;
            if (Physics.Raycast(transform.position, Vector3.forward, out hitNumber, Mathf.Infinity, badNumbersLayer))
            {
                Destroy(hitNumber.transform.gameObject);
            }
            if (Physics.Raycast(transform.position, Vector3.forward, out hitNumber, Mathf.Infinity, onesLayer))
            {
                Destroy(hitNumber.transform.gameObject);
            }
        }
    }
}
