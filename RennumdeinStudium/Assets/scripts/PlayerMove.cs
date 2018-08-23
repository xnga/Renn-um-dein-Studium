using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 5.0f;
    private Vector3 direction;


    // Use this for initialization
    void Start()
    {

        direction = Vector3.zero;       //Anfangspunkt

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector3.back;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector3.left;
        }

        float move = speed * Time.deltaTime;

        transform.Translate(direction * move);
    }
}