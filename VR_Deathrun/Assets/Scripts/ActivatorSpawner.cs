using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorSpawner : MonoBehaviour
{
    public GameObject spawnedObject;
    private Vector3 pos;
    public float xPos;
    public float yPos;
    public float zPos;
    public bool activated;
    public float cooldown;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        pos = new Vector3(xPos, yPos, zPos);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(activated){
            Instantiate(spawnedObject, pos, Quaternion.identity);
            activated = false;
        }
    }
}
