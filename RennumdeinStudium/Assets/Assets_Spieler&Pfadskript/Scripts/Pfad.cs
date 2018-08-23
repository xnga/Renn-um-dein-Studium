using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pfad : MonoBehaviour
{

    //public GameObject leftPathPrefab; ->gespeichert im Array: pathPrefabs
    //public GameObject topPathPrefab;

    public GameObject currentPath;

    public GameObject[] pathPrefabs;

    public HindernisSpawner hindernis;

    public Vector3 currentPfadPosition;

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
            //currentPfadPosition = pathPrefabs.position;


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

        //HindernisSpawner.Instance.StartRoutine();
        //hindernis = GameObject.Find("Pfad").GetComponent<HindernisSpawner>();


    }
}
