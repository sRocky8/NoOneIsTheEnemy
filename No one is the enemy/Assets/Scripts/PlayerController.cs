using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public Variables
    public float turnSpeed;
    public int health;
    [HideInInspector] public int score;

    //Private Variables
    private int badNumbersLayer = 1 << 8;
    private int onesLayer = 1 << 9;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-Vector3.up, turnSpeed, Space.World);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, turnSpeed, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hitNumber;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitNumber, Mathf.Infinity, badNumbersLayer))
            {
                Destroy(hitNumber.transform.gameObject);
                score += 1;
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitNumber.distance, Color.yellow);
            }
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitNumber, Mathf.Infinity, onesLayer))
            {
                Destroy(hitNumber.transform.gameObject);
                score -= 1;
            }
        }
    }
}
