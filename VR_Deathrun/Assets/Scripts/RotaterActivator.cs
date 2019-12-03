using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaterActivator : MonoBehaviour
{
    private bool activated;
    public GameObject controlledObject;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(activated){
            activated = false;
            controlledObject.GetComponent<Rotater>().activated = true;
        }
    }
}
