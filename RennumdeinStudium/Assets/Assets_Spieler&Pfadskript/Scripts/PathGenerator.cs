using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{

    public Transform pathParent;            //pathParent besitzt nur die Position
    public GameObject pathPref;             //=>Prefab Objekt
    public int maxTiles = 3;                //maximale Anzahl
    private GameObject lastPathTile;
    private List<GameObject> tiles;         //declaration
    private int pS;                         //previousStep

    //Hindernisspawner
    public GameObject Spawner;              // Prefab
    private GameObject lastSpawner;          // letzter Spawner
    public Transform spawnParent;

    //Collectspawner
    public GameObject ColSpawner;
    private GameObject lastColSpawner;          // letzter Spawner
    public Transform spawnColParent;


    //Zugriff auf HindernisSpawner.cs
    public HindernisSpawner spawnFunc;
    public spawemty spawnColFunc;
    //private List<List<GameObject>> hindernisList = new List<List<GameObject>>();
    public List<GameObject> colSpawnList;
    public List<GameObject> spawnerHindList;
    private int maxHinds = 45;


    [SerializeField]
    private int initialPathLength = 5;        //soviele werden von Anfang an generiert


	private void Start()
    {
        
        //hindernisList = new List<List<GameObject>>(); 
        tiles = new List<GameObject>();                     // tiles = Liste ->initialization
        lastPathTile = Instantiate(pathPref, pathParent);   // lastPathTile = Kopie von pathPref an Stelle von pathParent
        tiles.Add(lastPathTile);                            //lastPathTile wird der Liste hinzugefügt und ausgegeben

        lastSpawner = Instantiate(Spawner, spawnParent);
        spawnerHindList.Add(lastSpawner);
        lastColSpawner = Instantiate(ColSpawner, spawnColParent);
        colSpawnList.Add(lastColSpawner);
       

        for (int i = 0; i < initialPathLength; i++)
        {
            GeneratePathTile(1);                             //Erzeugung des Weges
        }
    }





    public void GeneratePathTile(int direction)
    {
        GameObject currentTile = null;
        GameObject currentSpawner = null;
        GameObject currentColSpawner = null;

        if (direction == 0 && pS != 0)                  //if Anweisung -> wo tile angehängt wird
        {
            currentTile = Instantiate(pathPref, lastPathTile.transform.position, lastPathTile.transform.rotation);  //kopiert pathPref, an Pos lastPathTile, rotiert um lastPathTile

            currentSpawner = Instantiate(Spawner, lastSpawner.transform.position, lastSpawner.transform.rotation); 
            currentColSpawner = Instantiate(ColSpawner, lastColSpawner.transform.position, lastColSpawner.transform.rotation); 

            currentTile.transform.parent = pathParent;                                                              //Zuweisung der Position von pathParent
            currentSpawner.transform.parent = spawnParent;
            currentColSpawner.transform.parent = spawnColParent;
        

            currentTile.transform.Rotate(0, -90, 0);                                                                //links
       
            currentSpawner.transform.Rotate(0, -90, 0);
            currentColSpawner.transform.Rotate(0, -90, 0);

            pS = direction;
        }

        else if (direction == 1)
        {
            currentTile = Instantiate(pathPref, lastPathTile.transform.position, lastPathTile.transform.rotation);
 

            currentSpawner = Instantiate(Spawner, lastSpawner.transform.position, lastSpawner.transform.rotation); 
            currentColSpawner = Instantiate(ColSpawner, lastColSpawner.transform.position, lastColSpawner.transform.rotation); 


            currentTile.transform.parent = pathParent;
            currentSpawner.transform.parent = spawnParent;
            currentColSpawner.transform.parent = spawnColParent;
        

            currentTile.transform.Rotate(0, 0, 0);                                                                  //vorne
      
            currentSpawner.transform.Rotate(0, 0, 0);
            currentColSpawner.transform.Rotate(0, 0, 0);


            pS = direction;
        }

        else if (direction == 2 && pS != 2)
        {
            currentTile = Instantiate(pathPref, lastPathTile.transform.position, lastPathTile.transform.rotation);
   
            currentSpawner = Instantiate(Spawner, lastSpawner.transform.position, lastSpawner.transform.rotation); 
            currentColSpawner = Instantiate(ColSpawner, lastColSpawner.transform.position, lastColSpawner.transform.rotation); 


            currentTile.transform.parent = pathParent;
            currentSpawner.transform.parent = spawnParent;
            currentColSpawner.transform.parent = spawnColParent;
     

            currentTile.transform.Rotate(0, 90, 0);                                                                 //rechts
  
            currentSpawner.transform.Rotate(0, 90, 0);
            currentColSpawner.transform.Rotate(0, 90, 0);


            pS = direction;
        }


        currentTile.transform.Translate(0, 0, lastPathTile.transform.localScale.z);                                     //verschiebt currentTile um die Größe des lastPathTiles z
        transform.position = currentTile.transform.position;

        currentSpawner.transform.Translate(0, 0, lastPathTile.transform.localScale.z);                                     
        transform.position = currentSpawner.transform.position;

        currentColSpawner.transform.Translate(0, 0, lastPathTile.transform.localScale.z);
        transform.position = currentColSpawner.transform.position;
  

        lastPathTile = currentTile;                                                                                     //lastPathTile ist nun currentTile
        lastSpawner = currentSpawner; 
        lastColSpawner = currentColSpawner; 

        tiles.Add(currentTile);                                                                                         //und currentTile wird der Liste hinzugefügt
    

        //SPAWNING Hindernisse & Collects
        spawnFunc.SpawnHindernisse(currentSpawner);
        spawnColFunc.spawncoll(currentColSpawner);

        spawnerHindList.Add(currentSpawner);
        colSpawnList.Add(currentColSpawner);

        //hindernisList.Add(spawnFunc.gespawnteHind);

        if (tiles.Count >= maxTiles)                                                                                    //wenn Anzahl tiles größer ist als die angegebene maximale Anzahl
        {
            GameObject killTile = tiles[0];
            tiles.RemoveAt(0);                                                                                         //die Verlinkung zum 0 Objekt wird gelöscht->Liste verschiebt sich
            Destroy(killTile);                                                                                         //und Objekt wird gelöscht

            GameObject killspawn = spawnerHindList[0];
            spawnerHindList.RemoveAt(0);                                                                                         
            Destroy(killspawn);

            GameObject killColspawn = colSpawnList[0];
            colSpawnList.RemoveAt(0);
            Destroy(killColspawn);
           
            //GameObject killHindernisse = hindernisList[0];
            //hindernisList.RemoveAt(0);
            //Destroy(killHindernisse);

        }





    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GeneratePathTile(Random.Range(0, 3));
        }
    }


}
