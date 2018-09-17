﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Tutorial: https://www.youtube.com/watch?v=QRp4V1JTZnM

public class Kollision : MonoBehaviour
{
    public bool playerDead;



	void Start()
	{
        playerDead = false;
	}

	void Update()
	{
        
	}

    void OnCollisionEnter(Collision colObject)
    {

        if (colObject.gameObject.name == "test(Clone)")
        {
            Destroy(this.gameObject);
            playerDead = true;
            ReloadGame();
        }

        if (colObject.gameObject.name == "test2(Clone)")
        {
            Destroy(this.gameObject);
            playerDead = true;
            ReloadGame();
        }

        if (colObject.gameObject.name == "stein(Clone)")
        {
            Destroy(this.gameObject);
            playerDead = true;
            ReloadGame();
        }
    }


    void ReloadGame()
    {

        GameOver.Instance.Dead();

    }

}