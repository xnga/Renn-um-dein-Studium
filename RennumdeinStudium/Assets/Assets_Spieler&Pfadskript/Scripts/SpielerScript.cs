using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerScript : MonoBehaviour {

    public float speed = 10;
    public float turnSpeed = 3;
    private Vector3 direction;
<<<<<<< HEAD
    
=======
    float horizontal;

>>>>>>> ade7df7024aafc4c240bc603979486de29cec4f6

	// Use this for initialization
	void Start () {
        
        direction = Vector3.zero;       //Anfangspunkt
		
	}
	
	// Update is called once per frame
	void Update () {

        horizontal = Input.GetAxis("Horizontal");
        
        if(Input.GetKeyDown(KeyCode.W)){
            direction = Vector3.forward;
        }
        if(Input.GetKeyDown(KeyCode.S)){
            direction = Vector3.back;
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


}
