using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pfad : MonoBehaviour
{

    //public GameObject leftPathPrefab; ->gespeichert im Array: pathPrefabs
    //public GameObject topPathPrefab;

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
            if (instance == null){
                instance = GameObject.FindObjectOfType<Pfad>();
            }
            return instance;
        }
    }


    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < 4; i++)
        {       //position z von player speichern und mit path vergleichen
            makePath();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makePath()
    {

        int randomInd = Random.Range(0, 2);     //Element 2 ist nicht mit enthalten

        currentPath = (GameObject)Instantiate(pathPrefabs[randomInd], currentPath.transform.GetChild(0).transform.GetChild(randomInd).position, Quaternion.identity);    //kopiert das Original und gibt die Kopie zurück && quaternion=natürliche Rot.

        if (randomInd == 0)
        {
            spawnerPos = new Vector3(currentPath.transform.position.x - 15 , currentPath.transform.position.y, currentPath.transform.position.z);
            Instantiate(spawner, spawnerPos, Quaternion.identity);
            HindernisSpawner.Instance.SpawnHindernisse(spawnerPos);
        }
        else
        {
            spawnerPos = new Vector3(currentPath.transform.position.x, currentPath.transform.position.y, currentPath.transform.position.z + 10);
            Instantiate(spawner, spawnerPos, Quaternion.identity);
            HindernisSpawner.Instance.SpawnHindernisse(spawnerPos);
        }
        //spawnerPos = new Vector3(currentPath.transform.position.x, currentPath.transform.position.y, currentPath.transform.position.z );
        //Instantiate(spawner, currentPath.transform.position, Quaternion.identity);

        //Instantiate(spawner, spawnerPos, Quaternion.identity);
        //HindernisSpawner.Instance.SpawnHindernisse();


        //SpawnerPos = GameObject.Find("Spawner").GetComponent<HindernisSpawner>();
        //SpawnerPos.spawnwerte = prefabPos;

     // Pos vom Spawner ändern >> spawnwerte == spawnerpos > noch nicht gegeben
        //currentSpawnPosition = GameObject.Find("Spawner").GetComponent<HindernisSpawner>();
        //currentSpawnPosition.spawnwerte = prefabPos;

    }


}
