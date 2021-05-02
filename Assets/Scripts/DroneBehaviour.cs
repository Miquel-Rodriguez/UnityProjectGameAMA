using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBehaviour : MonoBehaviour
{
    public float delta = 1.5f;  
    public float speed = 2.0f;
    private Vector3 startPos;
    public int life;
    DroneWeapon droneWeapon;
    public StopWaypoint stopWaypoint;
    public bool dead = false;
    RaycastHit hit;
    public float visionRange;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (!dead)
        {
            Vector3 v = startPos;
            v.x += delta * Mathf.Sin(Time.time * speed);
            transform.position = v;
        }
        else
        {
            gameObject.SetActive(false);
        }

       
    }

    public void LesslifeDrone(int damage)
    {
        life -= damage;
        print("Le he dado a un enemigo");
        if (life <= 0)
        {
            StopAllCoroutines();
            dead = true;
            stopWaypoint.numEnemies[stopWaypoint.aux] -= 1;


        }
    }

}
