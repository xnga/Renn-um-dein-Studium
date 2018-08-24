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

<<<<<<< HEAD
<<<<<<< HEAD
    public Vector3 currentPfadPosition;

   
=======
=======
>>>>>>> c54ce0e2397f0d8bc8f64e2823ddb058a3144154
    public Vector3 spawnerPos;


    private static Pfad instance;
<<<<<<< HEAD
>>>>>>> c54ce0e2397f0d8bc8f64e2823ddb058a3144154
=======
>>>>>>> c54ce0e2397f0d8bc8f64e2823ddb058a3144154


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
        {      
            makePath();
<<<<<<< HEAD
=======

            HindernisSpawner.Instance.SpawnHindernisse();


>>>>>>> c54ce0e2397f0d8bc8f64e2823ddb058a3144154

            HindernisSpawner.Instance.SpawnHindernisse();

<<<<<<< HEAD



<<<<<<< HEAD
        }



=======
        }
>>>>>>> c54ce0e2397f0d8bc8f64e2823ddb058a3144154
=======
        }
>>>>>>> c54ce0e2397f0d8bc8f64e2823ddb058a3144154
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makePath()
    {

        int randomInd = Random.Range(0, 2);     //Element 2 ist nicht mit enthalten

        currentPath = (GameObject)Instantiate(pathPrefabs[randomInd], currentPath.transform.GetChild(0).transform.GetChild(randomInd).position, Quaternion.identity);    //kopiert das Original und gibt die Kopie zurück && quaternion=natürliche Rot.

<<<<<<< HEAD
<<<<<<< HEAD


        //HindernisSpawner.Instance.StartRoutine();
        //hindernis = GameObject.Find("Pfad").GetComponent<HindernisSpawner>();
=======
=======
>>>>>>> c54ce0e2397f0d8bc8f64e2823ddb058a3144154
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
<<<<<<< HEAD
>>>>>>> c54ce0e2397f0d8bc8f64e2823ddb058a3144154
=======
>>>>>>> c54ce0e2397f0d8bc8f64e2823ddb058a3144154

     // Pos vom Spawner ändern >> spawnwerte == spawnerpos > noch nicht gegeben
        //currentSpawnPosition = GameObject.Find("Spawner").GetComponent<HindernisSpawner>();
        //currentSpawnPosition.spawnwerte = prefabPos;

    }



         

}
