using UnityEngine;
using System.Collections;
using System;

public class SpikeControl : MonoBehaviour
{
    Transform startMarker;
    public Transform endMarker;
    public float speed = 5f;
    private float startTime;
    private float journeyLength;
    float fractionOfJourney;
    bool activated = false;
    Animator anim;

    void Start()
    {
        startMarker = this.transform;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        
        float distCovered = (Time.time - startTime) * speed;
        fractionOfJourney = distCovered / journeyLength;
        if (Input.GetKeyDown(KeyCode.L) && !activated)
        {
            anim.SetTrigger("Activate");
            activated = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("stabbed lol");
        }
    }

}