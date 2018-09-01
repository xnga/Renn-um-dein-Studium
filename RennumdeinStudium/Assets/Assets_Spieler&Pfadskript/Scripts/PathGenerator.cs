using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour {

    public Transform pathParent;            //pathParent besitzt nur die Position
    public GameObject pathPref;             //=>Prefab Objekt
    public int maxTiles = 3;                //maximale Anzahl
    private GameObject lastPathTile;
    private List<GameObject> tiles;

    [SerializeField]
    private int initialPathLength = 5;        //soviele werden von Anfang an generiert

    private void Start()
    {
        tiles = new List<GameObject>();                     // tiles = Liste
        lastPathTile = Instantiate(pathPref, pathParent);   // lastPathTile = Kopie von pathPref an Stelle von pathParent
        tiles.Add(lastPathTile);                            //lastPathTile wird der Liste hinzugefügt und ausgegeben

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




    private void GeneratePathTile(int direction)
    {
        GameObject currentTile = null;
        switch (direction)                  //switch case -> wo tile angehängt wird
        {
            case 0:
                currentTile = Instantiate(pathPref, lastPathTile.transform.position, lastPathTile.transform.rotation);  //kopiert pathPref, an Pos lastPathTile, rotiert um lastPathTile
                currentTile.transform.parent = pathParent;                                                              //Zuweisung der Position von pathParent
                currentTile.transform.Rotate(0, -90, 0);                                                                //links
                break;

            case 1:
                currentTile = Instantiate(pathPref, lastPathTile.transform.position, lastPathTile.transform.rotation);
                currentTile.transform.parent = pathParent;
                currentTile.transform.Rotate(0, 0, 0);                                                                  //vorne
                break;

            case 2:
                currentTile = Instantiate(pathPref, lastPathTile.transform.position, lastPathTile.transform.rotation);
                currentTile.transform.parent = pathParent;
                currentTile.transform.Rotate(0, 90, 0);                                                                 //rechts
                break;

            default: break;
        }
        currentTile.transform.Translate(0, 0, lastPathTile.transform.localScale.z);                                     //verschiebt currentTile um die Größe des lastPathTiles z
        transform.position = currentTile.transform.position;                                                            


        lastPathTile = currentTile;                                                                                     //lastPathTile ist nun currentTile
        tiles.Add(currentTile);                                                                                         //und currentTile wird der Liste hinzugefügt

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
