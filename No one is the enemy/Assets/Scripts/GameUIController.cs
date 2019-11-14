using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    //Public Variables


    //Private Variables
    [SerializeField] private GameObject player;
    private int Health
    {
        get { return player.GetComponent<PlayerController>().health; }
    }
    private int Score
    {
        get { return player.GetComponent<PlayerController>().score; }
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
