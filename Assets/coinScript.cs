using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour {
    private int coinCounter;
	// Use this for initialization
	void Start () {
        coinCounter = 0; //Zu begin hat der Spieler null Punkte
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0,0, 90 *Time.deltaTime );
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player") //Tommi ist Player-Namensgebung achten
        {
            coinCounter++;
            Destroy(gameObject); //Destroy(other.gameObject);
            Debug.Log("Score:" + coinCounter);  //Punktestand wird ausgegeben
        }
    }
}
