using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial: https://www.youtube.com/watch?v=WGn1zvLSndk

public class HindernisSpawner : MonoBehaviour
{

    public GameObject[] hindernisse;
    public Vector3 spawnwerte;

    public List<GameObject> hindernisList = new List<GameObject>();
    public int maxHindernisse = 50;

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

            Instantiate(hindernisse[randomHindernis], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation); //Objecte spawnen

            hindernisList.Add(hindernisse[randomHindernis]);

            if (hindernisList.Count > maxHindernisse)                                                                     //wenn Anzahl tiles größer ist als die angegebene maximale Anzahl
            {
                GameObject killHindernis = hindernisList[0];
                hindernisList.RemoveAt(0);                                                                                         //die Verlinkung zum 0 Objekt wird gelöscht->Liste verschiebt sich
                Destroy(killHindernis);                                                                                         //und Objekt wird gelöscht

            }

        }
    }
}
