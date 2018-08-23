using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int points = 0;  //Punkte fängt bei 0 an

    void Start()
    {

    }

    void Update()
    {

    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score: " + points);
    }
}
