using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorSpawner : MonoBehaviour
{
    public GameObject spawnedObject;
    public GameObject player;
    public float threshold;
    private Vector3 pos;
    public float xPos;
    public float yPos;
    public float zPos;
    private bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(xPos, yPos, zPos);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <= threshold && activated == false){
            activated = true;
            Instantiate(spawnedObject, pos, Quaternion.identity);
        }
    }
}
