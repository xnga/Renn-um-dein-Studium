﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pfad : MonoBehaviour
{

    //public GameObject leftPathPrefab; ->gespeichert im Array: pathPrefabs
    //public GameObject topPathPrefab;

    public GameObject plane;

    public GameObject currentPath;

    public GameObject[] pathPrefabs;

    public GameObject spawner;
    public Vector3 spawnerPos;
    public Vector3 spawnPlace;

    private static Pfad instance;

    public static Pfad Instance             //mit Pfad.Instance können alle Funktionen aus der Klasse angesprochen werden
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Pfad>();
            }
            return instance;
        }
    }


    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < 40; i++)

        {
            makePath();

            HindernisSpawner.Instance.SpawnHindernisse(spawnerPos);
        }
        {
            makePath();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
        [SerializeField]
        public void makePath()

        {
        int randomInd = Random.Range(0, 2);     //Element 2 ist nicht mit enthalten

        currentPath = (GameObject)Instantiate(pathPrefabs[randomInd], currentPath.transform.GetChild(0).transform.GetChild(randomInd).position, Quaternion.identity);    //kopiert das Original und gibt die Kopie zurück && quaternion=natürliche Rot.

        plane = (GameObject)Instantiate(plane, new Vector3(currentPath.transform.position.x, currentPath.transform.position.y, currentPath.transform.position.z), Quaternion.identity);

        spawnerPos = new Vector3(currentPath.transform.position.x, currentPath.transform.position.y, currentPath.transform.position.z );
        Instantiate(spawner, currentPath.transform.position, Quaternion.identity);

        /* if (currentPath = pathPrefabs[0]) {
                 spawnerPos = new Vector3(currentPath.transform.position.x -15, currentPath.transform.position.y, currentPath.transform.position.z);
             }
             else
             {
                 spawnerPos = new Vector3(currentPath.transform.position.x, currentPath.transform.position.y, currentPath.transform.position.z+10);
             }*/
        //SpawnerPos = GameObject.Find("Spawner").GetComponent<HindernisSpawner>();
        //SpawnerPos.spawnwerte = prefabPos;

        // Pos vom Spawner ändern >> spawnwerte == spawnerpos > noch nicht gegeben
        //currentSpawnPosition = GameObject.Find("Spawner").GetComponent<HindernisSpawner>();
        //currentSpawnPosition.spawnwerte = prefabPos;

        {

            //int randomInd = Random.Range(0, 2);     //Element 2 ist nicht mit enthalten          currentPath = (GameObject)Instantiate(pathPrefabs[randomInd], currentPath.transform.GetChild(0).transform.GetChild(randomInd).position, Quaternion.identity);    //kopiert das Original und gibt die Kopie zurük && quaternion=natüliche Rot.          if (randomInd == 0)
            {
                spawnerPos = new Vector3(currentPath.transform.position.x - 15, currentPath.transform.position.y, currentPath.transform.position.z);
                Instantiate(spawner, spawnerPos, Quaternion.identity);
                spawnPlace = new Vector3(currentPath.transform.position.x + 15, currentPath.transform.position.y, currentPath.transform.position.z - 40);
                HindernisSpawner.Instance.SpawnHindernisse(spawnPlace);
            }
            else
            {
                spawnerPos = new Vector3(currentPath.transform.position.x, currentPath.transform.position.y, currentPath.transform.position.z + 10);
                Instantiate(spawner, spawnerPos, Quaternion.identity);
                spawnPlace = new Vector3(currentPath.transform.position.x, currentPath.transform.position.y, currentPath.transform.position.z - 50);
                HindernisSpawner.Instance.SpawnHindernisse(spawnPlace);
            }
            //spawnerPos = new Vector3(currentPath.transform.position.x, currentPath.transform.position.y, currentPath.transform.position.z );
            //Instantiate(spawner, currentPath.transform.position, Quaternion.identity);

            //Instantiate(spawner, spawnerPos, Quaternion.identity);
            //HindernisSpawner.Instance.SpawnHindernisse();


            //SpawnerPos = GameObject.Find("Spawner").GetComponent<HindernisSpawner>();
            //SpawnerPos.spawnwerte = prefabPos;

            // Pos vom Spawner ädern >> spawnwerte == spawnerpos > noch nicht gegeben
            //currentSpawnPosition = GameObject.Find("Spawner").GetComponent<HindernisSpawner>();
            //currentSpawnPosition.spawnwerte = prefabPos;

        }  

    }

}




