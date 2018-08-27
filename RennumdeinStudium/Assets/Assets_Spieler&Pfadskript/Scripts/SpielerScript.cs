using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerScript : MonoBehaviour {
    public int points = 0;


    public float speed = 10;
    public float turnSpeed = 3;
    private Vector3 direction;
    float horizontal;

    Animator animator;


	// Use this for initialization
	void Start () {

        //transform.position = new Vector3(0,1.5f,0);

        direction = Vector3.zero;       //Anfangspunkt

        animator = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {

        horizontal = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.W)){
            direction = Vector3.forward;
            animator.SetTrigger("run");

        }
        if(Input.GetKeyDown(KeyCode.S)){
            direction = Vector3.back;
            animator.SetTrigger("backwards-run");
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(0, horizontal * turnSpeed , 0);                       
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(0, horizontal * turnSpeed , 0);                      
        }

        float move = speed * Time.deltaTime;

        transform.Translate(direction * move);
	}

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score:" + points);
    }
}
