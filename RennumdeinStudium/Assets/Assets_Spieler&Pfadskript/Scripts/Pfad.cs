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
    //public GameObject currentSpawner;

    public Vector3 spawnerPos;

    public GameObject terrain;

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

        for (int i = 0; i < 40; i++)
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

        terrain = (GameObject)Instantiate(terrain, new Vector3(currentPath.transform.position.x, currentPath.transform.position.y, currentPath.transform.position.z), Quaternion.identity);

        spawnerPos = new Vector3(currentPath.transform.position.x, currentPath.transform.position.y, currentPath.transform.position.z );
        Instantiate(spawner, currentPath.transform.position, Quaternion.identity);

        HindernisSpawner.Instance.SpawnHindernisse();

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

    }
}
