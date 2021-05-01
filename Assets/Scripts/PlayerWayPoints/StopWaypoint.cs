using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopWaypoint : MonoBehaviour
{
    [SerializeField]CinemachineDollyCart player;
    public MoveGunWithMouse moveCam;
    public GameObject[] lights;
    public GameObject playerLight;
    public int aux;
    public int[] numEnemies;
    
    private void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("Light");

    }
    private void Update()
    {
       if (numEnemies[aux] <= 0)
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
            aux += 1;          
            other.enabled = false;
        }

        if (other.tag == "WaypointBoss")
        {
            Stop();
            playerLight.SetActive(false);
           

            foreach (GameObject go in lights)
            {
                go.SetActive(true);
            }
        }

        if (other.tag == "ExitToBoss")
        {
            ChangeSceneToBoss();

        }

        if (other.tag == "ExitToRoom")
        {
            ChangeSceneToRoom();

        }

        if (other.tag == "End")
        {
            End();

        }

    }

    private void Stop()
    {
        player.enabled = false;
        moveCam.enabled = true;
       
        
    }

    private void ChangeSceneToBoss()
    {
        //TODO fade out/in
        SceneManager.LoadScene("BossScene");
    }

    private void ChangeSceneToRoom()
    {
        //TODO fade out/in
        SceneManager.LoadScene("RoomScene");
    }

    private void End()
    {
        //TODO mensaje de end y fade out
    }
}
