using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial: https://www.youtube.com/watch?v=WGn1zvLSndk

public class HindernisSpawner : MonoBehaviour
{

    public GameObject[] hindernisse;
    public Vector3 spawnwerte;

    Quaternion rotationBook = Quaternion.Euler(0, 0, 90);
    Quaternion rotationTisch = Quaternion.Euler(0, 0, 180);
    Quaternion rotationStone = Quaternion.Euler(0, 0, 0);

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
        //spawnwerte = new Vector3(0, 0, 0);
        SpawnHindernisse();

    }


    public void Update()
    {
    }

    public void SpawnHindernisse()
    {
        
        for (int i = 0; i < 5; i++)
        {

            int randomHindernis = Random.Range(0, 3); // Welches Object gespawnt? arrayplaetze, welches Object gepickt wird

            Vector3 spawnPosition = new Vector3(Random.Range(spawnwerte.x + 13f , spawnwerte.x - 13f), spawnwerte.y + 0.5f, Random.Range(spawnwerte.z + 13f, spawnwerte.z - 13f)); // Wo Object gespawnt?

            if(randomHindernis == 0)
                Instantiate(hindernisse[0], spawnPosition + transform.TransformPoint(0, 0, 0), rotationTisch); //Objecte spawnen
            if (randomHindernis == 1)
                Instantiate(hindernisse[1], spawnPosition + transform.TransformPoint(0, 0, 0), rotationBook); //Objecte spawnen
            if (randomHindernis == 2)
                Instantiate(hindernisse[2], spawnPosition + transform.TransformPoint(0, 0, 0), rotationStone); //Objecte spawnen


        }
    }
}
