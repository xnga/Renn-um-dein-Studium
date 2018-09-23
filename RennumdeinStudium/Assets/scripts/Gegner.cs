using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Umsetzung des Skripts erfolgte durch Ideen aus "RabbitBehaviour" von Herrn Pattmann und Hilfe von Herrn Dietze

public class Gegner : MonoBehaviour
{
    private GameObject player;
    private GameObject enemy;
    private Vector3 target = Vector3.zero;
    public float rotSpeed = 0.5f;
    public float speedEnemy;
    public float distance;
    
    // anderers Skript "SpielerScript" bekanntmachen
    SpielerScript spielerScript;

    private void Awake()
    {
        spielerScript = (SpielerScript)GameObject.FindGameObjectWithTag("Player").GetComponent("SpielerScript");
    }

    // Use this for initialization
    void Start()
    {


        player = GameObject.Find("free_male_1");
        enemy = GameObject.Find("Enemy");

        //Anfangsposition fuer Enemy bestimmen
        enemy.transform.position = player.transform.position - new Vector3( 0.0f, -5.0f, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
    
        // Zuweisung des Targets
        target = player.transform.position;

        distance = Vector3.Distance(enemy.transform.position, target);

        // Hier wird die Richtung ermittelt.
        Vector3 targetDir = (target - enemy.transform.position).normalized;
        targetDir.y = 0f;

        //für eine Distanz kleiner als 5
        if (distance < 3.0f)
        {
            //Grundgeschwindigkeit fuer Entfernung
            speedEnemy = 6.0f;
            spielerScript.AlterHealth(Time.deltaTime - 0.25f);
            spielerScript.UpdateGUI();
        }

        else if (distance < 15.0f){
            speedEnemy = 10.0f;
            spielerScript.AlterHealth(Time.deltaTime - 0.05f);
            spielerScript.UpdateGUI();
        }

        else
        {
            speedEnemy = 15.5f;
            spielerScript.UpdateGUI();
        }


        //Geschwindigkeit für Bewegung ermitteln
        float step = speedEnemy * Time.deltaTime;

        //Bewegung des Enemys
        enemy.transform.forward = Vector3.RotateTowards(enemy.transform.forward, targetDir, rotSpeed, 0.0f);
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target + new Vector3(0.0f, 1.5f, -2.0f), step);
        

    }

}