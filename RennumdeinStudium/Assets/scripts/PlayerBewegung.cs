using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraVerfolgung : MonoBehaviour {


    float timemoved = 2.0f;
    GameObject pfad;


    int vertindex = 0;

    void move(float length)
    {
        // Eckpunkte erzeugen
        Vector3 a = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + transform.right * 0.5f;

        // Zweiten Punkt zu a parallel verschieben
        Vector3 b = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) - transform.right * 0.5f;

        // Transform-Turtle um ganze Laenge verschieben
        this.transform.Translate(0, 0, length);

        Vector3 c = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + transform.right * 0.5f;

        Vector3 d = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) - transform.right * 0.5f;

        // Listen-Index um 4 weiterschieben
        vertindex += 4;
    }

    void turnHorizontal(float angle_y)
    {
        this.transform.Rotate(0, angle_y, 0);
    }

    void turnVertical(float angle_x)
    {
        this.transform.Rotate(angle_x, 0, 0);
    }


    void Start()
    {

        Update();
    }

    void Update()
    {

        if ((Time.time - timemoved) > 0.5f)
        {
            timemoved = Time.time;
            move(1.0f);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            turnVertical(-90.0f);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            turnHorizontal(-90.0f);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            turnVertical(90.0f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            turnHorizontal(90.0f);
        }
    }
}
