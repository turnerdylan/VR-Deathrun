using UnityEngine;
using System.Collections;
using System;

public class SpikeControl : MonoBehaviour
{
    bool activated = false;
    Animator anim;
    PlatformControls player;
    public float threshold;

    public AudioClip stab;
    AudioSource source;


    void Start()
    {
        player = FindObjectOfType<PlatformControls>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Vector3.Distance(player.transform.position, this.transform.parent.position) <= threshold && !activated)
        {
            anim.SetTrigger("Activate");
            source.PlayOneShot(stab, 0.7f);
            activated = true;
        }
    }
}