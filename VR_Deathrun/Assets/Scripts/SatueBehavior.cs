using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatueBehavior : MonoBehaviour
{
    public float destroyTimer = 10f;
    private GameObject player;
    public float threshold = 20f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        destroyTimer -= Time.deltaTime;
        if(Vector3.Distance(transform.position, player.transform.position) <= threshold){
            rb.AddForce(0, 0, 100);
            //Debug.Log("Slam");
        }
        if(destroyTimer <= 5){
            rb.AddForce(0, 50, 0);
        }
        if(destroyTimer <= 0){
            Destroy(gameObject);
        }
    }
}
