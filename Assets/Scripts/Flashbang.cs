using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashbang : MonoBehaviour
{

    public float delay = 3f;
    public float radius = 5f;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    void Start()
    {
        countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        GameObject flashLight =   Instantiate(explosionEffect, transform.position, transform.rotation);
        FindObjectOfType<AudioManager>().Play("ExplosionFlash");

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.gameObject.CompareTag("Enemy"))
            {
                nearbyObject.gameObject.GetComponent<EnemySoldier>().flashed = true;
                nearbyObject.gameObject.GetComponent<EnemySoldier>().Flashed();
                print("Enemigo ");
            }


        }
        Destroy(flashLight, 0.1f);
        print("me estoy apunto de destruir");
        Destroy(gameObject);
    }
}
