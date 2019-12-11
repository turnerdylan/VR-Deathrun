using UnityEngine;
using System.Collections;
using System;

public class SpikeControl : MonoBehaviour
{
    bool activated = false;
    Animator anim;
    public GameObject player;
    public float threshold;


    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(Vector3.Distance(player.transform.position, this.transform.parent.position) <= threshold && !activated)
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