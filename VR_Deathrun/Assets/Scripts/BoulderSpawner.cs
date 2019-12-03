using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSpawner : MonoBehaviour
{
    public GameObject boulder;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(0, 15, 24);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)){
            Instantiate(boulder, pos, Quaternion.identity);
        }
    }
}
