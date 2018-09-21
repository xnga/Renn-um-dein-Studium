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

    //public GameObject plane;
    //public Transform planeParent;
    //private GameObject lastPlane;

    //Zugriff auf HindernisSpawner.cs
    private HindernisSpawner spawnskript;

    [SerializeField]
    private int initialPathLength = 5;        //soviele werden von Anfang an generiert

	private void Awake()
	{
        spawnskript = GetComponent<HindernisSpawner>();
	}

	private void Start()
    {
        

        tiles = new List<GameObject>();                     // tiles = Liste ->initialization
        lastPathTile = Instantiate(pathPref, pathParent);   // lastPathTile = Kopie von pathPref an Stelle von pathParent
        tiles.Add(lastPathTile);                            //lastPathTile wird der Liste hinzugefügt und ausgegeben

        lastSpawner = Instantiate(Spawner, spawnParent);
        lastColSpawner = Instantiate(ColSpawner, spawnColParent);
        //lastPlane = Instantiate(plane, planeParent);
        //tiles.Add(lastPlane);

        for (int i = 0; i < initialPathLength; i++)
        {
            GeneratePathTile(1);                             //Erzeugung des Weges
        }
    }



    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Keypad4)) GeneratePathTile(0);
    //    if (Input.GetKeyDown(KeyCode.Keypad8)) GeneratePathTile(1);
    //    if (Input.GetKeyDown(KeyCode.Keypad6)) GeneratePathTile(2);
    //}




    public void GeneratePathTile(int direction)
    {
        GameObject currentTile = null;
        GameObject currentSpawner = null;
        GameObject currentColSpawner = null;
        //GameObject currentPlane = null;

        if (direction == 0 && pS != 0)                  //if Anweisung -> wo tile angehängt wird
        {
            currentTile = Instantiate(pathPref, lastPathTile.transform.position, lastPathTile.transform.rotation);  //kopiert pathPref, an Pos lastPathTile, rotiert um lastPathTile
            //currentPlane = Instantiate(plane, lastPlane.transform.position, lastPlane.transform.rotation);

            currentSpawner = Instantiate(Spawner, lastSpawner.transform.position, lastSpawner.transform.rotation); 
            currentColSpawner = Instantiate(ColSpawner, lastColSpawner.transform.position, lastColSpawner.transform.rotation); 

            currentTile.transform.parent = pathParent;                                                              //Zuweisung der Position von pathParent
            currentSpawner.transform.parent = spawnParent;
            currentColSpawner.transform.parent = spawnColParent;
            //currentPlane.transform.parent = planeParent;

            currentTile.transform.Rotate(0, -90, 0);                                                                //links
            //currentPlane.transform.Rotate(0, -90, 0);
            currentSpawner.transform.Rotate(0, -90, 0);
            currentColSpawner.transform.Rotate(0, -90, 0);

            pS = direction;
        }

        else if (direction == 1)
        {
            currentTile = Instantiate(pathPref, lastPathTile.transform.position, lastPathTile.transform.rotation);
            //currentPlane = Instantiate(plane, lastPlane.transform.position, lastPlane.transform.rotation);

            currentSpawner = Instantiate(Spawner, lastSpawner.transform.position, lastSpawner.transform.rotation); 
            currentColSpawner = Instantiate(ColSpawner, lastColSpawner.transform.position, lastColSpawner.transform.rotation); 


            currentTile.transform.parent = pathParent;
            currentSpawner.transform.parent = spawnParent;
            currentColSpawner.transform.parent = spawnColParent;
            //currentPlane.transform.parent = planeParent;

            currentTile.transform.Rotate(0, 0, 0);                                                                  //vorne
            //currentPlane.transform.Rotate(0, 0, 0);
            currentSpawner.transform.Rotate(0, 0, 0);
            currentColSpawner.transform.Rotate(0, 0, 0);


            pS = direction;
        }

        else if (direction == 2 && pS != 2)
        {
            currentTile = Instantiate(pathPref, lastPathTile.transform.position, lastPathTile.transform.rotation);
            //currentPlane = Instantiate(plane, lastPlane.transform.position, lastPlane.transform.rotation);

            currentSpawner = Instantiate(Spawner, lastSpawner.transform.position, lastSpawner.transform.rotation); 
            currentColSpawner = Instantiate(ColSpawner, lastColSpawner.transform.position, lastColSpawner.transform.rotation); 


            currentTile.transform.parent = pathParent;
            currentSpawner.transform.parent = spawnParent;
            currentColSpawner.transform.parent = spawnColParent;
            //currentPlane.transform.parent = planeParent;

            currentTile.transform.Rotate(0, 90, 0);                                                                 //rechts
            //currentPlane.transform.Rotate(0, 90, 0);
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

        //currentPlane.transform.Translate(0, 0, lastPlane.transform.localScale.z);
        //transform.position = currentPlane.transform.position;

        lastPathTile = currentTile;                                                                                     //lastPathTile ist nun currentTile
        lastSpawner = currentSpawner; 
        lastColSpawner = currentColSpawner; 
        //lastPlane = currentPlane;

        tiles.Add(currentTile);                                                                                         //und currentTile wird der Liste hinzugefügt
        //tiles.Add(currentPlane);

        //SPAWNING Hindernisse & Collects
        //spawnskript.SpawnHindernisse(currentSpawner);
        HindernisSpawner.Instance.SpawnHindernisse(currentSpawner);
        spawemty.Instance.spawncoll(currentColSpawner);

        //Instantiate(spawner2, currentTile.transform.position, Quaternion.identity);                                      // Objekte werden gespawnt
        //spawemty.Instance.spawncoll();

        if (tiles.Count >= maxTiles)                                                                                    //wenn Anzahl tiles größer ist als die angegebene maximale Anzahl
        {
            GameObject killTile = tiles[0];
            tiles.RemoveAt(0);                                                                                         //die Verlinkung zum 0 Objekt wird gelöscht->Liste verschiebt sich
            Destroy(killTile);                                                                                         //und Objekt wird gelöscht

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
