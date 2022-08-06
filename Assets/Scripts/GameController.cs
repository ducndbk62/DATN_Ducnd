﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject menu;
    public GameObject nextLvBtn;
    public Text txtPoint, enemiesNumber;
    public GameObject txtVictory;
    public AudioClip victorySound;

    public GameObject enemyParent;

    private int currentPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        if (SceneManager.GetActiveScene().name != "Endless")
        {
            txtPoint.gameObject.SetActive(false);
        }
        enemiesNumber.text = enemyParent.transform.childCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Endless")
        {
            if (enemyParent.transform.childCount == 0)
                CompleteLevel();
        }
        else
        {
            enemiesNumber.text = enemyParent.transform.childCount.ToString();
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.N))
        {
            CompleteLevel();
        }
#endif
    }

    public void GetPoint(int point)
    {
        if (SceneManager.GetActiveScene().name == "Endless")
        {
            currentPoint++;
            txtPoint.text = currentPoint.ToString();
        }
        else
        {
            enemiesNumber.text = enemyParent.transform.childCount.ToString();
        }
    }

    private void CompleteLevel()
    {
        Time.timeScale = 0;
        gameObject.GetComponent<AudioSource>().clip = victorySound;
        gameObject.GetComponent<AudioSource>().Play();
        menu.SetActive(true);
        txtVictory.SetActive(true);
        nextLvBtn.SetActive(true);
        int currentLv = int.Parse(SceneManager.GetActiveScene().name);
        if (currentLv >= PlayerPrefs.GetInt("LevelProgress"))
        {
            PlayerPrefs.SetInt("LevelProgress", currentLv + 1);
        }
    }

    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        gameObject.GetComponent<AudioSource>().Play();
        menu.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
