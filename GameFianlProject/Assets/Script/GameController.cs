using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static bool isGameAlive = true;
    //public static CameraShake camShake;
    
    public GameObject gameOverPanel;
    public static GameController Instance;

    void Start()
    {
        Instance = this;
    }

    void Update()
    {
       
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
