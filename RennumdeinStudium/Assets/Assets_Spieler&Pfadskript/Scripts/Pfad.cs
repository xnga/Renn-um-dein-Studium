using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pfad : MonoBehaviour {

    public GameObject leftPathPrefab;

    public GameObject currentPath;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < 10; i++){
            makePath();

        }

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void makePath(){

        currentPath = (GameObject)Instantiate(leftPathPrefab, currentPath.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity);    //kopiert das Original und gibt die Kopie zurück && quaternion=natürliche Rot.
                                                            
    }
}
