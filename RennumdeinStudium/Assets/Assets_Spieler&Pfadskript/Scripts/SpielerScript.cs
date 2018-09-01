using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpielerScript : MonoBehaviour {
    public int points = 0;

    


    public float speed = 10;
    public float turnSpeed = 3;
    private Vector3 direction;
    float horizontal;

    Animator animator;

    /* public float Health;
     private float healthOverTime;   



         public float Stamina;
     public float staminaOverTime;
     */




    public float Hunger;
    public float hungerOverTime;

    public float Thirst;
    public float thirstOverTime;


    public Slider Hungerbar;
    public Slider Thirstbar;
    /*public Slider HealthBar;
    public Slider StaminaBar;
   
    */


    public float minAmount = 5f;
    public float sprintSpeed = 5f;

    Rigidbody myBody;
    

    // Use this for initialization
    void Start () {

        myBody = GetComponent<Rigidbody>();
        Thirstbar.maxValue = Thirst;
        Hungerbar.maxValue = Hunger;


        /*HealthBar.maxValue = Health;
        StaminaBar.maxValue = Stamina;
        */

        updateUI();

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


        CalculateValues();
	}




    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score:" + points);
    }

    private void CalculateValues()
    {
        Hunger -= hungerOverTime * Time.deltaTime;
        Thirst -= thirstOverTime * Time.deltaTime;
        
        /*if(Hunger<= minAmount || Thirst <= minAmount)
        {
            Health -= healthOverTime * Time.deltaTime;
            Stamina -= staminaOverTime * Time.deltaTime;

        }
        */

        if(myBody.velocity.magnitude>=sprintSpeed && myBody.velocity.y == 0)
        {
            //Stamina -= staminaOverTime * Time.deltaTime;
            Hunger -= hungerOverTime * Time.deltaTime;
            Thirst -= thirstOverTime * Time.deltaTime;
        }
        /*else
        {
            Stamina += staminaOverTime * Time.deltaTime;

        }*/

        /*if (Health <= 0)
        {
            print("Player has died");
        }*/

        updateUI();

    }

    private void updateUI()
    {
        /*Thirstbar.maxValue = Thirst;
        Hungerbar.maxValue = Hunger;

        Health = Mathf.Clamp(Health, 0f, 100f);
        Stamina = Mathf.Clamp(Health, 0f, 100f); */

        Hunger = Mathf.Clamp(Hunger, 0f, 100f);
        Thirst = Mathf.Clamp(Thirst, 0f, 100f);
       

        Thirstbar.value = Thirst;
        Hungerbar.value = Hunger;
        /*HealthBar.value = Health;
        StaminaBar.value = Stamina;*/


    }

   /* public void TakeDamage(float amt)
    {
        Health -= amt;
        updateUI();
    }*/

}

//https://www.youtube.com/watch?v=8lv8mCehpuE z