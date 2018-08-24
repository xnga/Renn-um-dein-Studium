﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial: https://www.youtube.com/watch?v=WGn1zvLSndk

public class HindernisSpawner : MonoBehaviour
{

    public GameObject[] hindernisse;
    //public Vector3 spawnwerte; // braucht immer aktuelle werte vom akutellen pfadsegment oder position von player plus/minus

    private static HindernisSpawner instanceHindernissspawner;

    public static HindernisSpawner Instance             //andere Skripte können auf Funktionen aus der Klasse zugreifen
    {
        get
        {
            if (instanceHindernissspawner == null)
            {
                instanceHindernissspawner = GameObject.FindObjectOfType<HindernisSpawner>();
            }
            return instanceHindernissspawner;
        }
    }


    public void Start()
    {

        // SpawnHindernisse();

    }


    public void Update()
    {



    }

    public void SpawnHindernisse( Vector3 spawnwerte)
    {

        //spawnwerte = Pfad.Instance.spawnPlace;

        for (int i = 0; i < 8; i++)
        {

            int randomHindernis = Random.Range(0, 3); // Welches Object gespawnt? arrayplaetze, welches Object gepickt wird

            Vector3 spawnPosition = new Vector3(Random.Range(spawnwerte.x + 15, spawnwerte.x - 15), spawnwerte.y + 2, Random.Range(spawnwerte.z - 10, spawnwerte.z + 10)); // Wo Object gespawnt?

            Instantiate(hindernisse[randomHindernis], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation); //Objecte spawnen



        }
    }
}
