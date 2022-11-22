using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{


    //camera
    public float camRotationSpeed = -1.5f;
    public float rotationSpeed = 2.0f;

    //speed settings
    public float maxSpeed;
    public float normalSpeed = 10.0f;
    public float sprintSpeed = 20.0f;

    //sprint and jump settings
    public float maxSprint = 5.0f;
    float sprintTimer;
    public float jumpForce = 300.0f;


    //camera settings
    float rotation = 0.0f;
    float camRotation = 0.0f;

    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;

    GameObject cam;
    Rigidbody myRigidbody;

    public bool canSprint = false;
    public bool canClimb = false;
    public bool canJump = false;
    public bool canClimbFast = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        myRigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        sprintTimer = maxSprint;

    }


    // Update is called once per frame
    void Update()
    {


        Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed) +
                              (transform.right * Input.GetAxis("Horizontal") * maxSpeed);
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

        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);


        sprintTimer = Mathf.Clamp(sprintTimer, 0.0f, maxSprint);


    }


    void jump()
    {
        //When have half of legs
        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.AddForce(transform.up * jumpForce);
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

}
