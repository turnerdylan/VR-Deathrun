using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public GameObject player;
    public float threshold;
    public float rotSpeed = 5f;
    public float rotDuration = 5f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <= threshold && timer <= rotDuration){
            this.transform.Rotate(rotSpeed, 0, 0);
            timer += Time.deltaTime;
        }
    }
}
