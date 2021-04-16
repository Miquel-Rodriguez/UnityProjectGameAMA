using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWaypoint : MonoBehaviour
{
    [SerializeField]CinemachineDollyCart player;
    public EnemySoldier enemy;
    public MoveGunWithMouse moveCam;
    
    private void Start()
    {
        

    }
    private void Update()
    {
       if (enemy.deadth)
        {
            player.enabled = true;
            moveCam.enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Waypoint")
        {
            Stop();

        }

    }

    private void Stop()
    {
        player.enabled = false;
        moveCam.enabled = true;
       
        
    }
}
