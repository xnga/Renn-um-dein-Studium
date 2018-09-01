
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*if (playerDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }*/
	}


    private static GameOver gameOver;

    public static bool GamePause = false;

    public GameObject GameOverMenuUI;

    public static GameOver Instance             //andere Skripte können auf Funktionen aus der Klasse zugreifen
    {
        get
        {
            if (gameOver == null)
            {
                gameOver = GameObject.FindObjectOfType<GameOver>();
            }
            return gameOver;
        }
    }

    public void Dead() {

        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GamePause = true;

    }

    public void LoadGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
//dead = GameObject.Find("free_male_1").GetComponent<Kollision>();
//dead.playerDead = true;
