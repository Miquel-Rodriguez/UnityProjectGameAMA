using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWaypoint : MonoBehaviour
{
    CinemachineDollyCart player;
    
    private void Start()
    {
        

    }
    private void Update()
    {
       

    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Waypoint")
        {
            StartCoroutine(Stop());

        }

    }

    IEnumerator Stop()
    {
        player.enabled = false;
        yield return new WaitForSeconds(3f);
        player.enabled = true;
        
    }
}
