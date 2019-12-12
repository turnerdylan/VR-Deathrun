using UnityEngine;
using System.Collections;
using System;

public class SpikeControl : MonoBehaviour
{
    bool activated = false;
    Animator anim;
    PlatformControls player;
    public float threshold;


    void Start()
    {
        player = FindObjectOfType<PlatformControls>();
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
}