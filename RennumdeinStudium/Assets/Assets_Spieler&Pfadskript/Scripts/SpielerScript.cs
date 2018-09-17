using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

<<<<<<< HEAD
<<<<<<< HEAD
public class SpielerScript : MonoBehaviour
=======
public class SpielerScript : MonoBehaviour
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
=======
public class SpielerScript : MonoBehaviour
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
{
    public int points = 0;


    public float speed = 10;
    public float turnSpeed = 20;
    public float jumpStrength = 5f;
    float horizontal;
    float vertical;

    public bool isGrounded = true;
    private float distToGround = 0f;


    Animator anim;

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

<<<<<<< HEAD
<<<<<<< HEAD
    Rigidbody myBody;


    // Use this for initialization
    void Start()
=======
=======
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
    Rigidbody myBody;


    // Use this for initialization
    void Start()
<<<<<<< HEAD
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
=======
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
    {
        anim = GetComponent<Animator>();

        myBody = GetComponent<Rigidbody>();
        Thirstbar.maxValue = Thirst;
        Hungerbar.maxValue = Hunger;


        /*HealthBar.maxValue = Health;
        StaminaBar.maxValue = Stamina;
        */

<<<<<<< HEAD
<<<<<<< HEAD
        //updateUI();


    }

    // Update is called once per frame
    void Update()
=======
=======
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
        //updateUI();


    }

    // Update is called once per frame
    void Update()
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
<<<<<<< HEAD
<<<<<<< HEAD

        float _speed = speed * Time.deltaTime;


=======
=======
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524

        float _speed = speed * Time.deltaTime;


<<<<<<< HEAD
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += transform.forward * _speed * Input.GetAxis("Vertical");
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.position += transform.forward * _speed * Input.GetAxis("Vertical");
<<<<<<< HEAD
=======
          
        }
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
=======
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += transform.forward * _speed * Input.GetAxis("Vertical");
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.position += transform.forward * _speed * Input.GetAxis("Vertical");
          
        }
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524

        //Animation abspielen, wenn vertical!=0
        if( (vertical > 0) && vertical < 0)
        {
            anim.SetTrigger("run");
        }
<<<<<<< HEAD
<<<<<<< HEAD

        //Animation abspielen, wenn vertical!=0
        if ((vertical > 0) && vertical < 0)
        {
            anim.SetTrigger("run");
        }
=======
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
        else
        {
=======
        else
        {
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
            anim.ResetTrigger("run");
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, horizontal * turnSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, horizontal * turnSpeed * Time.deltaTime, 0);
        }
<<<<<<< HEAD
    }

    private void FixedUpdate()
    {

        distToGround = GetComponent<CapsuleCollider>().bounds.extents.y;                //Distanz y-Achse
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround);    //Raycast misst die Distanz von der Pos. des Spielers zum Boden



=======
    }

    private void FixedUpdate()
    {

        distToGround = GetComponent<CapsuleCollider>().bounds.extents.y;                //Distanz y-Achse
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround);    //Raycast misst die Distanz von der Pos. des Spielers zum Boden



<<<<<<< HEAD
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
=======
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)                              //wenn die Leertaste gerdückt ist & Spieler auf dem Boden steht
        {
            GetComponent<Rigidbody>().AddForce(0, jumpStrength, 0);                     //Stärke der Kraft hinzufügen
            anim.SetTrigger("Jump");
        }

        CalculateValues();

<<<<<<< HEAD
<<<<<<< HEAD
        if (isGrounded == false)
        {
            anim.ResetTrigger("Jump");
        }
=======
        if (isGrounded == false){
            anim.ResetTrigger("Jump");
        }
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
=======
        if (isGrounded == false){
            anim.ResetTrigger("Jump");
        }
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
    }




    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score:" + points);
    }

    private void CalculateValues()
    {
        Hunger -= hungerOverTime * Time.deltaTime;
<<<<<<< HEAD
<<<<<<< HEAD
        Thirst -= thirstOverTime * Time.deltaTime;

=======
        Thirst -= thirstOverTime * Time.deltaTime;

>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
=======
        Thirst -= thirstOverTime * Time.deltaTime;

>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
        /*if(Hunger<= minAmount || Thirst <= minAmount)
        {
            Health -= healthOverTime * Time.deltaTime;
            Stamina -= staminaOverTime * Time.deltaTime;

        }
<<<<<<< HEAD
<<<<<<< HEAD
        */

=======
        */

>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
=======
        */

>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
        /*if(myBody.velocity.magnitude>=sprintSpeed && myBody.velocity.y == 0)
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
<<<<<<< HEAD
<<<<<<< HEAD
        }*/


       // updateUI();
=======
=======
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
        }*/


        updateUI();
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524

    }

   // private void updateUI()
    //{
        /*Thirstbar.maxValue = Thirst;
        Hungerbar.maxValue = Hunger;

        Health = Mathf.Clamp(Health, 0f, 100f);
        Stamina = Mathf.Clamp(Health, 0f, 100f); */

<<<<<<< HEAD
<<<<<<< HEAD
        //Hunger = Mathf.Clamp(Hunger, 0f, 100f);
        //Thirst = Mathf.Clamp(Thirst, 0f, 100f);


        //Thirstbar.value = Thirst;
        //Hungerbar.value = Hunger;
=======
=======
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
        Hunger = Mathf.Clamp(Hunger, 0f, 100f);
        Thirst = Mathf.Clamp(Thirst, 0f, 100f);


        Thirstbar.value = Thirst;
        Hungerbar.value = Hunger;
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
        /*HealthBar.value = Health;
        StaminaBar.value = Stamina;*/


<<<<<<< HEAD
    //} 
}

/* public void TakeDamage(float amt)
 {
     Health -= amt;
     updateUI();
 }*/



/*private void OnGUI()
{
    GUI.Label(new Rect(10, 10, 100, 20), "Score:" + points);
}
*/
//
=======
    }
}

   /* public void TakeDamage(float amt)
    {
        Health -= amt;
        updateUI();
    }*/



    /*private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score:" + points);
    }
*/
//
<<<<<<< HEAD
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
=======
>>>>>>> de1106b8314a09cdfe7d4e361536edfe9cc87524
