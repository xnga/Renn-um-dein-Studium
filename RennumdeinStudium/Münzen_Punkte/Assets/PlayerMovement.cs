
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        // transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);
        rb.MovePosition(transform.position + movement);

        //transform.Translate(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);
    }
}
