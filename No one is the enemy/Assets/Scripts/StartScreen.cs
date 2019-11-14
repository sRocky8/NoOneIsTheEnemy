using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private Button startButton; 

    public void OnButtonClick(string buttonName)
    {
        if (buttonName == startButton.name)
        {
            SceneManager.LoadScene(1);
        }
    }
}
