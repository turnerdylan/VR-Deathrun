using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsAThing : MonoBehaviour
{
    float xMove;
    float zMove;
    Rigidbody rb;
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(xMove, 0, zMove) * moveSpeed;
    }
}
