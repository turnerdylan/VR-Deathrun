using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lethal : MonoBehaviour
{
    PlatformControls player;

    private void Start()
    {
        player = FindObjectOfType<PlatformControls>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.KillPlayer();
        }
    }
}
