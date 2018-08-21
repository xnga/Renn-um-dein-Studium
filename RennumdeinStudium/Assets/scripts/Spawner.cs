using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial: https://www.youtube.com/watch?v=WGn1zvLSndk

public class Spawner : MonoBehaviour {

    public GameObject[] hindernisse;
    public Vector3 spawnwerte = new Vector3(15.0f, 0.0f, 10.0f); // braucht immer aktuelle werte vom akutellen pfadsegment oder position von player plus/minus
    public float spawnWarten = 0.0f; //wartezeit bevor spawnt
    public float spawnMostWarten = 0.5f; // um zwischen spawnvariablen zu switchen
    public float spawnLeastWarten = 0.1f; // um zwischen spawnvariablen zu switchen
    public int startWarten = 0;

    int randomHindernis;


	void Start () {

        StartCoroutine(waitSpawner());

	}
	
	void Update () {

        spawnWarten = Random.Range(spawnLeastWarten, spawnMostWarten); // Kreiert eine random Zeit in der gespawnt wird / Unterschiedliche Zeitabstaende

	}

    IEnumerator waitSpawner () {

        yield return new WaitForSeconds(startWarten);

        while (true) {

            randomHindernis = Random.Range(0, 3); // Welches Object gespawnt? arrayplaetze, welches Object gepickt wird

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnwerte.x, spawnwerte.x), spawnwerte.y, Random.Range(-spawnwerte.z, spawnwerte.z)); // Wo Object gespawnt?

            Instantiate(hindernisse[randomHindernis], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation); //Objecte spawnen

            yield return new WaitForSeconds(spawnWarten);
        }
    }
}
