using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRepositioner : MonoBehaviour
{
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.parent.transform.position = Player.transform.position;
    }
}
