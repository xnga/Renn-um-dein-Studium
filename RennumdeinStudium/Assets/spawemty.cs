using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial: https://www.youtube.com/watch?v=WGn1zvLSndk

public class spawemty: MonoBehaviour
{
    Quaternion rotationcol = Quaternion.Euler(-90, 0, 0);

    public GameObject[] hindernisse;
    public Vector3 spawnwerte;

    private static spawemty instanceHindernissspawner;

    public static spawemty Instance             //andere Skripte können auf Funktionen aus der Klasse zugreifen
    {
        get
        {
            if (instanceHindernissspawner == null)
            {
                instanceHindernissspawner = GameObject.FindObjectOfType<spawemty>();
            }
            return instanceHindernissspawner;
        }
    }


    public void Start()
    {
        //spawnwerte = new Vector3(0, 0, 0);
      
        spawncoll();
    

    }


    public void Update()
    {
     
    }

    public void spawncoll()
    {

        for (int i = 0; i < 5; i++)
        {

            int randomHindernis = Random.Range(0, 2); // Welches Object gespawnt? arrayplaetze, welches Object gepickt wird

            Vector3 spawnPosition = new Vector3(Random.Range(spawnwerte.x + 13f, spawnwerte.x - 13f), spawnwerte.y + 3.0f, Random.Range(spawnwerte.z + 13f, spawnwerte.z - 13f)); // Wo Object gespawnt?

            Instantiate(hindernisse[randomHindernis], spawnPosition + transform.TransformPoint(0, 0, 0), rotationcol); //Objecte spawnen


        }
    }
}
