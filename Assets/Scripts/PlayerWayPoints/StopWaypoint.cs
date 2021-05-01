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
           
            moveCam.enabled = false;
            StartCoroutine(move());
            player.enabled = true;

        }
    }

    public IEnumerator move()
    {
        yield return new WaitForSeconds(2f);

    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Waypoint"))
        {
            
            Stop();
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
        aux += 1;

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
