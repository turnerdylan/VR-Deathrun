using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFloor1 : MonoBehaviour
{
    public GameObject player;
    public float threshold = 10;
    public float moveDist = 5;
    private bool moved = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <= threshold && !moved){
            this.transform.Translate(0, 0, moveDist);
            moved = true;
        }
    }
}
