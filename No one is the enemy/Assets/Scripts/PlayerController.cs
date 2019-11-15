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
    [SerializeField] private GameObject enemyExplosion;
    [SerializeField] private AudioSource hurt;
    [SerializeField] private AudioSource healed;
    //[SerializeField] private Transform target;
    //[SerializeField] private float smoothTime;
    //[SerializeField] private float velocity;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (health > 0)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(-Vector3.up, turnSpeed, Space.World);
                //float newRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, transform.eulerAngles.y - turnSpeed, ref velocity, smoothTime); //
                //transform.rotation = Quaternion.Euler(0, newRotation, 0);
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
                    Instantiate(enemyExplosion, hitNumber.transform.position, Quaternion.identity);
                    Destroy(hitNumber.transform.gameObject);
                    score += 1;
                    //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitNumber.distance, Color.yellow);
                }
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitNumber, Mathf.Infinity, onesLayer))
                {
                    Instantiate(enemyExplosion, hitNumber.transform.position, Quaternion.identity);
                    Destroy(hitNumber.transform.gameObject);
                    score -= 11;
                }
            }
        }
        if(score < 0)
        {
            score = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy"){
            Destroy(other.gameObject);
            health -= 1;
            hurt.Play();
        }
        if (other.tag == "One")
        {
            Destroy(other.gameObject);
            health += 1;
            healed.Play();
        }
    }
}
