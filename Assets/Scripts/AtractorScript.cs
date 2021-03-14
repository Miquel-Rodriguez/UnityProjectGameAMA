using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AtractorScript : MonoBehaviour{

    public float AttractorSpeed;

    private GameObject player;
    private GameObject loot;

    public Text textoLoot;

    private void Start()
    {
        player = GameObject.Find("Player");
        loot = gameObject;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, AttractorSpeed * Time.deltaTime);
            if (player.transform.position == loot.transform.position)
            {
                StartCoroutine(ShowMessage());
            }
        }
    }


    IEnumerator ShowMessage()
    {
        textoLoot.gameObject.SetActive(true);
        textoLoot.text = "Has obtenido: " + loot.name;
        yield return new WaitForSeconds(1);
        textoLoot.gameObject.SetActive(false);
        Destroy(loot);
    }
}
