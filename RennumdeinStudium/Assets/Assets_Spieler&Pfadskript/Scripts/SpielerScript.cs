using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpielerScript : MonoBehaviour
{
    public int points = 0;
    public Text score;

    public int maxGesundheit; // Wie viel Health der Player MAXIMUM hat
    public Text curHealthLabel; // Einfügen von Health TXT
    private int currentHealth; // 100%
    public Image EndeScreen;
    private bool isDead;
  

    public float speed = 10;
    public float turnSpeed = 20;
    public float jumpStrength = 5f;
    float horizontal;
    float vertical;
    public bool isGrounded = true;
    private float distToGround = 0f;
    Animator anim;
    public float minAmount = 5f;
    public float sprintSpeed = 5f;
    Rigidbody myBody;
    

    // Use this for initialization
    void Start()
    {
        currentHealth = maxGesundheit; //Fängt bei MAX an 
        isDead = false; // wenn bool falsch ist, dann wird GUI geaupdatet, also wird die Zahl runter gehen
        UpdateGUI();



        anim = GetComponent<Animator>();

        myBody = GetComponent<Rigidbody>();

    }


    void UpdateGUI()
    {
        curHealthLabel.text = currentHealth.ToString(); // hier wird das mit dem Runterzählen durchgeführt
        EndeScreen.gameObject.SetActive(isDead); //SetActive setzt das Image dann ein

        score.text = points.ToString(); // hier wird das mit dem Runterzählen durchgeführt
    }

    public void AlterHealth(int amt)
    {
        currentHealth += amt;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxGesundheit); //(Wert den wir einschränken wollen, minimun Wert, maximum Wert)
        CheckDead();
        UpdateGUI();
    }
    // Update is called once per frame
    private void CheckDead()
    {
        if (isDead)
            return; // isDead ist ein bool, das false ist; spricht: wenn das false ist, wird es returnt
        if (currentHealth == 0) // wenn das Minimum erreicht wird, also true ist, dann soll im Player Script das Image erscheinen 
        {
            isDead = true;
            GetComponent<SpielerScript>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        float _speed = speed * Time.deltaTime;


        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += transform.forward * _speed * Input.GetAxis("Vertical");
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.position += transform.forward * _speed * Input.GetAxis("Vertical");
          
        }

        //Animation abspielen, wenn vertical!=0
        if( (vertical > 0) && vertical < 0)
        {
            anim.SetTrigger("run");
        }
        else
        {
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
    }

    private void FixedUpdate()
    {

        distToGround = GetComponent<CapsuleCollider>().bounds.extents.y;                //Distanz y-Achse
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround);    //Raycast misst die Distanz von der Pos. des Spielers zum Boden



        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)                              //wenn die Leertaste gerdückt ist & Spieler auf dem Boden steht
        {
            GetComponent<Rigidbody>().AddForce(0, jumpStrength, 0);                     //Stärke der Kraft hinzufügen
            anim.SetTrigger("Jump");
        }
   
        if (isGrounded == false){
            anim.ResetTrigger("Jump");
        }
    }


}
