using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopWaypoint : MonoBehaviour
{
    [SerializeField]CinemachineDollyCart player;
    [SerializeField] Scene2Controller sceneController;
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
            StartCoroutine(ChangeSceneToBoss());

        }

        if (other.tag == "ExitToRoom")
        {
            StartCoroutine(ChangeSceneToRoom());

        }

        if (other.tag == "End")
        {
            StartCoroutine(End());

        }


    }

    private void Stop()
    {
        player.enabled = false;
        moveCam.enabled = true;
        aux += 1;

    }

    private IEnumerator ChangeSceneToBoss()
    {
        sceneController.FadeIn();
        yield return new WaitForSeconds(1);
        //TODO fade out/in
        SceneManager.LoadScene("BossScene");
    }

    private IEnumerator ChangeSceneToRoom()
    {
        sceneController.FadeIn();
        yield return new WaitForSeconds(1);
        //TODO fade out/in
        SceneManager.LoadScene("RoomScene");
    }

    private IEnumerator End()
    {
        sceneController.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("FinalScene");
        //TODO mensaje de end y fade out
    }

}
