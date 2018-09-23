using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial: https://www.youtube.com/watch?v=WGn1zvLSndk

public class spawemty: MonoBehaviour
{
    Quaternion rotationcol = Quaternion.Euler(-90, 0, 0);

    public GameObject[] collect;

    public List<GameObject> gespawnteCols;

    public void Update()
    {
     
    }

    public void spawncoll(GameObject spawner)
    {
        gespawnteCols = new List<GameObject>();
        Vector3 spawnwerte = new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z);

        for (int i = 0; i < 5; i++)
        {

            int randomHindernis = Random.Range(0, 2); // Welches Object gespawnt? arrayplaetze, welches Object gepickt wird

            Vector3 spawnPosition = new Vector3(Random.Range(spawnwerte.x + 13f, spawnwerte.x - 13f), spawnwerte.y + 2.0f, Random.Range(spawnwerte.z + 13f, spawnwerte.z - 13f)); // Wo Object gespawnt?

            Instantiate(collect[randomHindernis], spawnPosition + transform.TransformPoint(0, 0, 0), rotationcol); //Objecte spawnen

            gespawnteCols.Add(collect[randomHindernis]); //speichert Hindernisse in Liste
        }
    }
}
