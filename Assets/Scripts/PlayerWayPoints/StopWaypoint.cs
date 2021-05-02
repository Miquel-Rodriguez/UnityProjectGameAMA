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
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public int aux;
    public int[] numEnemies;
    public bool enMovimiento;
    
    private void Start()
    {
        

    }
    private void Update()
    {
        
        if (numEnemies[aux] <= 0 && Input.GetKey("space") == false)
        {


            moveCam.enabled = false;
            player.enabled = true;


        }

        if (player.enabled == true)
        {
            enMovimiento = true;
        }
        else
        {
            enMovimiento = false;
        }
    }

    public IEnumerator move()
    {
        yield return new WaitForSeconds(2f);
        moveCam.enabled = false;
        player.enabled = true;
        

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

            light1.SetActive(true);
            light2.SetActive(true);
            light3.SetActive(true);

            other.enabled = false;

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
