using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Umsetzung des Skripts erfolgte durch Ideen aus "RabbitBehaviour" von Herrn Pattmann und 

public class Gegner : MonoBehaviour
{
    private GameObject player;
    private GameObject enemy;
    private Vector3 target = Vector3.zero;
    public float rotSpeed = 0.5f;
    public float speed;

    //Variable Kaffee holen!!!
    //Variable Lebensanzeige holen!!!



    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("free_male_1");
        enemy = GameObject.Find("Enemy");

        //Anfangsposition fuer Enemy bestimmen
        enemy.transform.position = player.transform.position - new Vector3(-20.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Zuweisung des Targets
        target = player.transform.position;

        float distance = Vector3.Distance(enemy.transform.position, target);

        // unterschiedliche Szenarien bei unterschiedlichen Entfernungen
        if (distance > 1)
        {
            // Hier wird die Richtung ermittelt (macht das Transform richtung obsolet).
            Vector3 targetDir = (target - enemy.transform.position).normalized;
            targetDir.y = 0f;

            //für eine Distanz kleiner als 3
            if (distance < 3)
            {
                //Grundgeschwindigkeit fuer Entfernung
                speed = 7.0f;

                //bei niedriger Kaffeezahl wird die Geschwindigkeit des Gegners hoeher
                /* if (kaffee <= 33) 
                {
                    speed =+ speed * 1.5;
                } 
                else if (kaffee > 33 && kaffee <= 66)
                {
                    speed =+ speed;
                }
                else if (kaffee > 66)
                {
                    speed =- speed;
                }
                */
            }

            // für Distanz zwischen 5 und 3
            else if (distance < 6 && distance >= 3) 
            {
                speed = 10.0f;
                /* if (kaffee <= 33) 
                {
                    speed =+ speed * 1.5;
                } 
                    else if (kaffee > 33 && kaffee <= 66)
                {
                    speed =+ speed;
                }
                    else if (kaffee > 66)
                {
                    speed =- speed;
                }
                */
            }

            //Geschwindigkeit für Bewegung ermitteln
            float step = speed * Time.deltaTime;

            //Bewegung des Enemys
            enemy.transform.forward = Vector3.RotateTowards(enemy.transform.forward, targetDir, rotSpeed, 0.0f);
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target, step);
        }

        // Spielende bei Kollision mit Enemy
       else if (distance <= 1) 
        {
            Destroy(player.gameObject);
        } 


    }
}