using UnityEngine;
using System.Collections;
using System;

public class SpikeControl : MonoBehaviour
{
    Transform startMarker;
    public Transform endMarker;
    public float speed = 5f;
    private float startTime;
    private float journeyLength;
    float fractionOfJourney;
    bool activated = false;

    void Start()
    {
        startMarker = this.transform;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }
    void Update()
    {
        
        float distCovered = (Time.time - startTime) * speed;
        fractionOfJourney = distCovered / journeyLength;
        if (Input.GetKeyDown(KeyCode.Space) && !activated)
        {
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
        }
        else
        {
            //transform.position = Vector3.Lerp(endMarker.position, startMarker.position, fractionOfJourney / 5);
        }
    }

    private IEnumerator ShootSpike()
    {
        
        activated = true;
        yield return new WaitForSeconds(5);
        Debug.Log("delayed");
        
    }
}