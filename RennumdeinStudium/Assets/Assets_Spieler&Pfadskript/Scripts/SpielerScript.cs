using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerScript : MonoBehaviour {
    public int points = 0;


    public float speed = 10;
    public float turnSpeed = 20;
    public float jumpStrength = 5f;
    //private Vector3 direction;
    float horizontal;

    public bool isGrounded = true;
    private float distToGround = 0f;


    //[SerializeField] Rigidbody rb; //um einzelne Werte hinzuzufügen

    Animator animator;


	// Use this for initialization
	void Start () {

        //direction = Vector3.zero;       //Anfangspunkt

        //animator = GetComponent<Animator>();
		
	}

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");
        float _speed = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            //direction = Vector3.forward;
            transform.position += transform.forward * _speed;
            animator.SetTrigger("run");

        }
        else if (Input.GetKey(KeyCode.S))
        {
            //direction = Vector3.back;
            transform.position += -transform.forward * _speed;
           // animator.SetTrigger("backwards-run");
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, horizontal * turnSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, horizontal * turnSpeed * Time.deltaTime, 0);
        }
    }

        private void FixedUpdate()
        {
            distToGround = GetComponent<CapsuleCollider>().bounds.extents.y;                //Distanz y-Achse
            isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround);    //Raycast misst die Distanz von der Pos. des Spielers zum Boden



            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)                              //wenn die Leertaste gerdückt ist & Spieler auf dem Boden steht
            {
                GetComponent<Rigidbody>().AddForce(0, jumpStrength, 0); //Stärke der Kraft hinzufügen
            }
        }

    }

    /*private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score:" + points);
    }
*/

