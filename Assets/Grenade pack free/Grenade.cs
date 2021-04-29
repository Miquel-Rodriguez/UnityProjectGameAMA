using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    [SerializeField] private float delay = 3f;
    [SerializeField] private float radius = 5f;

    [SerializeField] private GameObject explosionEffect;

    [SerializeField] private float countdown;
    private bool hasExploded;

    void Start()
    {
        countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
       
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            print(nearbyObject.tag);
            if(nearbyObject.gameObject.CompareTag("Enemy")){
                nearbyObject.gameObject.GetComponent<EnemySoldier>().Lesslife(100);
                print("Enemigo ");
            }
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
    }
}
