<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerScript : MonoBehaviour
{

    public float speed = 10;
    public float turnSpeed = 3;
    private Vector3 direction;


    

    float horizontal;



    // Use this for initialization
    void Start()
    {


        direction = Vector3.zero;       //Anfangspunkt

    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, horizontal * turnSpeed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, horizontal * turnSpeed, 0);
        }

        float move = speed * Time.deltaTime;

        transform.Translate(direction * move);
    }


}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerScript : MonoBehaviour
{

    public float speed = 10;
    public float turnSpeed = 3;
    private Vector3 direction;

    float horizontal;

    // Use this for initialization
    void Start()
    {

        direction = Vector3.zero;       //Anfangspunkt

    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, horizontal * turnSpeed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, horizontal * turnSpeed, 0);
        }

        float move = speed * Time.deltaTime;

        transform.Translate(direction * move);
    }


}
>>>>>>> ef39854e93b7acad6b41084ca17057f0266ad395
