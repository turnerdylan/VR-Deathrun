using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControls : MonoBehaviour
{

    public float speed = 10.0f;
    private float translation;
    private float straffe;
    Rigidbody rb;
    public float jump = 10;
    Collider[] isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public Vector3 currentSpawnPoint;

    public Transform camera;

    // Use this for initialization
    void Start()
    {
        currentSpawnPoint = transform.position;
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.OverlapSphere(groundCheck.position, checkRadius, whatIsGround);
        for(int i=0; i<isGrounded.Length; i++)
        {
            if (Input.GetButtonDown("Fire1") && isGrounded[i].gameObject.layer == 9)
            {
                rb.AddForce(0, jump, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float yRot = camera.transform.eulerAngles.y;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRot, transform.eulerAngles.z); 

        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);
        //rb.velocity = new Vector3(straffe, 0, translation);


        if (Input.GetKeyDown("escape"))
        {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Lethal")
        {
            KillPlayer();
        }
        if (other.gameObject.tag == "Victory")
        {
            transform.position = new Vector3(60, 3, 60);
        }
    }

    


    public void KillPlayer()
    {
        Debug.Log("you died");
        transform.position = currentSpawnPoint;
    }
}