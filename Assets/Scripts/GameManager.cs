﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;
    [SerializeField]
    private GameObject _pauseMenu;

    public string GetScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        return sceneName;
    }

    private void Update()
    {
        GameRestarter();
        PauseGame();
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    public void GameRestarter()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            StartCoroutine(RestartGame());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    IEnumerator RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Single_Player")
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1); // Game Game Scene
        }

        if (currentScene.name == "Co-Op_Mode")
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2); // Game Game Scene
        }

        yield return null;
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            _pauseMenu.SetActive(true);
        }
    }
}
