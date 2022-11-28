 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterController : MonoBehaviour
{

    

    [Header("camera")]
    public float camRotationSpeed = -1.5f;
    public float rotationSpeed = 2.0f;


    [Header("speed settings")]
    public float maxSpeed;
    public float normalSpeed = 10.0f;
    public float sprintSpeed = 20.0f;

    [Header("sprint and jump settings")]
    public float maxSprint = 5.0f;
    float sprintTimer;
    public float jumpForce = 300.0f;

    [Header("climb settings")]
    public float climbSpeed;
    public float grav;

    [Header("camera settings")]
    float rotation = 0.0f;
    float camRotation = 0.0f;

    bool isOnGround;
    bool isOnWall;
    public GameObject groundChecker;
    public GameObject wallChecker;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public int skullPoints; 

    GameObject cam;
    Rigidbody myRigidbody;

    [Header("Booleans")]
    public bool canSprint = false;
    public bool canClimb = false;
    public bool canJump = false;
    public bool canClimbFast = false;
    public bool knife = false;
    public bool heart = false;
    public bool ribcage = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        myRigidbody = GetComponent<Rigidbody>();
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        sprintTimer = maxSprint;

        gameObject.tag = "Player";

    }


    // Update is called once per frame
    void Update()
    {
        

        Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed) + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);

        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);

        //cam settings
        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));


        //first leg piece
        if (canJump == true)
        {
            jump();
        }

        camRotation = Mathf.Clamp(camRotation, -40.0f, 40.0f);

        //second leg piece
        if (canSprint == true)
        {
            sprint();
        }

        //first arm piece
        if(canClimb == true)
        {
            wallclimb();
        }
        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);
        isOnWall = Physics.CheckSphere(wallChecker.transform.position, 0.1f, wallLayer);


        sprintTimer = Mathf.Clamp(sprintTimer, 0.0f, maxSprint);

        


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Leg 1")
        {
            canJump = true;

          
        }

        if (other.tag == "Leg 2")
        {
            canSprint = true;

     
        }

        if (other.tag == "Arm 1")
        {
            canClimb = true;

        }

        if (other.tag == "Joints")
        {
            canClimbFast = true;


        }

        if (other.tag == "Heart")
        {
            heart = true;

        }

        if (other.tag == "Knife")
        {
            knife = true;

   
        }

        if (other.tag == "Ribcage")
        {
            ribcage = true;

        }

        if (other.tag == "Skull")
        {
            skullPoints = skullPoints + 1;
        }

    }

    void jump()
    {
        //When have half of legs
        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

    }

    void sprint()
    {
        //when have all legs
        if (Input.GetKey(KeyCode.LeftShift) && sprintTimer > 0.0f)
        {
            maxSpeed = sprintSpeed;
            sprintTimer = sprintTimer - Time.deltaTime;
        }
        else
        {
            maxSpeed = normalSpeed;
            if (Input.GetKey(KeyCode.LeftShift) == false)
            {
                sprintTimer = sprintTimer + Time.deltaTime;

            }
        }
    }

    void wallclimb()
    {
        if(isOnWall && Input.GetKey(KeyCode.W))
        {
            myRigidbody.useGravity = false;
            myRigidbody.AddForce(transform.up * climbSpeed, ForceMode.Force);

        }
        if (!isOnWall)
        {
            myRigidbody.useGravity = true;
            myRigidbody.AddForce(transform.up * grav, ForceMode.Impulse);
        }
    }
}
