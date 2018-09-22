using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial: https://www.youtube.com/watch?v=WGn1zvLSndk

public class HindernisSpawner : MonoBehaviour
{

    public GameObject[] hindernisse ;

    public List<GameObject> gespawnteHind;
    private int maxHinds = 45;

    Quaternion rotationBook = Quaternion.Euler(0, 0, 90);
    Quaternion rotation = Quaternion.Euler(0, 0, 0);


    public void Start()
    {
        
    }


    public void Update()
    {
    }

    public void SpawnHindernisse(GameObject spawner)
    {
        gespawnteHind = new List<GameObject>();
        Vector3 spawnwerte = new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z);

        for (int i = 0; i < 5; i++)
        {

            int randomHindernis = Random.Range(0, 3); // Welches Object gespawnt? arrayplaetze, welches Object gepickt wird

            Vector3 spawnPosition = new Vector3(Random.Range(spawnwerte.x + 13f, spawnwerte.x - 13f), spawnwerte.y + 0.5f, Random.Range(spawnwerte.z + 13f, spawnwerte.z - 13f)); // Wo Object gespawnt?

            if (randomHindernis == 0)
                Instantiate(hindernisse[0], spawnPosition + transform.TransformPoint(0, 0, 0), rotation); //Objecte spawnen
            if (randomHindernis == 1)
                Instantiate(hindernisse[1], spawnPosition + transform.TransformPoint(0, 0, 0), rotationBook); //Objecte spawnen
            if (randomHindernis == 2)
                Instantiate(hindernisse[2], spawnPosition + transform.TransformPoint(0, 0, 0), rotation); //Objecte spawnen

            //hindList.hindernisList.Add(hindernisse[randomHindernis]);
            gespawnteHind.Add(hindernisse[randomHindernis]); //speichert Hindernisse in Liste

        }
    }
}
