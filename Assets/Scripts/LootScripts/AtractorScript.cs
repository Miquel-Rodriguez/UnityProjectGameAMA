﻿using UnityEngine;

public class AtractorScript : MonoBehaviour
{

    public float AttractorSpeed;

    private GameObject player;
    [SerializeField]
    public Transform target;


    private void Start()
    {
        player = GameObject.Find("Player");
    }


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, AttractorSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            print("entrnado loot");
            Movement movement = collision.gameObject.GetComponent<Movement>();
            movement.ShowMessage(gameObject.name);
            Destroy(gameObject);

        }
    }
}

