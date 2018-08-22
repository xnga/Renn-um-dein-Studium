using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endlosPfad : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit(Collider other)
    {     //sobald der Spieler den Collider verlässt wird die Funktion aufgerufen

        if (other.tag == "Player")
        {
            Pfad.Instance.makePath();
        }
    }
}