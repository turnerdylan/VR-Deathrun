using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    PlatformControls player;
    Vector3 thisSpawnPoint;
    public GameObject flame;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlatformControls>();
        flame.gameObject.SetActive(false);
        thisSpawnPoint = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        flame.gameObject.SetActive(true);
        player.currentSpawnPoint = thisSpawnPoint;
    }
}
