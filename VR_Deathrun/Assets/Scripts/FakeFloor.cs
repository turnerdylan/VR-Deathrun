using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFloor : MonoBehaviour
{
    public GameObject player;
    public float threshold = 10;
    public float dropRate = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <= threshold){
            this.transform.Translate(0, 0, dropRate);
        }
    }
}
