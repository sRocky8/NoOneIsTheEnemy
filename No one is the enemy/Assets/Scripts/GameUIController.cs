using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    //Public Variables

    
    //Private Variables
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image crosshair;
    [SerializeField] private Image redTint;
    [SerializeField] private Button startOver;
    [SerializeField] private Button exitGame;
    private GameObject[] enemies;
    private bool turnedOnDeathUI;
    private int Health
    {
        get { return player.GetComponent<PlayerController>().health; }
    }
    private int Score
    {
        get { return player.GetComponent<PlayerController>().score; }
    }

    private void Start()
    {
        turnedOnDeathUI = false;
        AliveOrNotUI(true, false);
    }

    void Update()
    {
        healthSlider.value = Health;
        scoreText.text = "Score: " + Score;

        if (Health <= 0)
        {
            if(turnedOnDeathUI == false){
                Destroy(enemySpawner.gameObject);
                AliveOrNotUI(false, true);

                //https://answers.unity.com/questions/1376098/destroy-all-objects-with-same-name.html
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    Destroy(enemy);
                }

                highScoreText.text = "High Scores:\n";

                turnedOnDeathUI = false;
            }
        }
    }

    public void OnButtonClick(string buttonName)
    {
        if (buttonName == startOver.name)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (buttonName == exitGame.name)
        {
            Application.Quit();
        }
    }

    private void AliveOrNotUI(bool crosshairOn, bool deathUIOn)
    {
        crosshair.gameObject.SetActive(crosshairOn);
        healthSlider.gameObject.SetActive(crosshairOn);
        redTint.gameObject.SetActive(deathUIOn);
        startOver.gameObject.SetActive(deathUIOn);
        exitGame.gameObject.SetActive(deathUIOn);
        gameOverText.gameObject.SetActive(deathUIOn);
//        highScoreText.gameObject.SetActive(deathUIOn);
    }
}
