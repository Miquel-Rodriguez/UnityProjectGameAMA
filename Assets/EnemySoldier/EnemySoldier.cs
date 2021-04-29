﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldier : MonoBehaviour
{

    Animator animator;
    [SerializeField]
    Transform enemyEyes;
    [SerializeField]
    int visionRange;
    [SerializeField]
    Transform player;

    [SerializeField]
    Transform playerContainer;

    RaycastHit hit;

    private float timeShoot;
    private float waiteToShoot;
    private float waitToDown = 1;
    private float waitToUp;

    [SerializeField]
    SoldierWeapon weaponScript;

    [SerializeField] int maxTimeShooting;
    [SerializeField] int minTimeShooting;

    [SerializeField] int minTimewaitToShoot;
    [SerializeField] int maxTimeWaitToShoot;

    [SerializeField] int minTimewaitwaitToDown;
    [SerializeField] int maxTimeWaitwaitToDown;

    [SerializeField] int minTimewaitToUp;
    [SerializeField] int maxTimeWaitToUp;

    bool down=false;

    bool shooting = false;

    [SerializeField] int life = 100;

    private Vector3 offset = new Vector3(0, 0.5f, 0);

    public bool deadth;

    bool vengoDeAbajo=false;
    [SerializeField]
    bool  runing;

    public bool flashed;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Down", true);
    //    animator.speed = 2;
    }
    
    private void Update()
    {
        if (!deadth)
        {
            print(flashed);

            if (runing)
            {
                
                    animator.SetBool("Run", true);
                
                
            }
            else
            {
                animator.SetBool("Run", false);


                RotateTowards(player, transform);
                RotateTowards(player, enemyEyes);

                if (WatchingPlayer() && !shooting && !flashed)
                {
                    Shoot();
                }
                else if (!WatchingPlayer())
                {
                    animator.SetBool("NormalShooting", false);
                }

                if (Time.time >= waitToDown && !down)
                {
                    down = true;
                    StartCoroutine(Down());
                }

                Debug.DrawRay(enemyEyes.position, enemyEyes.forward * visionRange, Color.red);
            }
        }
        else
        {
            Lesslife(100);

        }
    }

    private bool WatchingPlayer()
    {

        return Physics.Raycast(enemyEyes.position, enemyEyes.forward, out hit, visionRange) && hit.collider.CompareTag("Player") ;

    }




    public void Shoot()
    {
        shooting = true;
        animator.SetBool("NormalShooting", true);
        StartCoroutine(Shooting());


    }

    public IEnumerator Down()
    {
        vengoDeAbajo = true;
        weaponScript.disparar = false;
        enemyEyes.position = transform.position+new Vector3(0,1,0);
        animator.SetBool("NormalShooting", false);
        animator.SetBool("Down", true);
        waitToUp = Random.Range(minTimewaitToUp, maxTimeWaitToUp);
        yield return new WaitForSeconds(waitToUp);
        waitToDown = Time.time + Random.Range(minTimewaitwaitToDown, maxTimeWaitwaitToDown);
        animator.SetBool("Down", false);
        down = false;
        enemyEyes.position = transform.position + new Vector3(0, 1.75f, 0);
       
    }

    public IEnumerator Shooting()
    {
        timeShoot = Random.Range(minTimeShooting, maxTimeShooting);
        waiteToShoot = Random.Range(minTimewaitToShoot, maxTimeWaitToShoot);

        if (vengoDeAbajo)
        {
            StartCoroutine(activateshot());
        }
        else
        {
            weaponScript.disparar = true;
        }
        
       
        yield return new WaitForSeconds(timeShoot);

        weaponScript.disparar = false;
        animator.SetBool("NormalShooting", false);


        yield return new WaitForSeconds(waiteToShoot);
        shooting = false;
    }

    private IEnumerator activateshot()
    {
        yield return new WaitForSeconds(0.5f);
        weaponScript.disparar = true;
        vengoDeAbajo = false;
    }


    public void Lesslife(int damage)
    {
        life -= damage;
        print("Le he dado a un enemigo");
        if (life <= 0)
        {

            FindObjectOfType<AudioManager>().Play("MuerteEnemigo");

            weaponScript.disparar = false;
            StopAllCoroutines();
            deadth = true;
            animator.SetBool("Die", true);
            InstantiateLoot ins = GetComponent<InstantiateLoot>();
            ins.InsantieteLoots();
        }
    }

    public static void RotateTowards(Transform player, Transform npc, float speed = 2.0f)
    {

        Vector3 direction = (player.position - npc.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        npc.rotation = Quaternion.Slerp(npc.rotation, lookRotation, Time.deltaTime * speed);

    }

    public void Flashed()
    {
        weaponScript.flashed = true;
        StartCoroutine(Desflashear());
    }

    private IEnumerator Desflashear()
    {
        yield return new WaitForSeconds(2);
        weaponScript.flashed = false;
        flashed = false;
    }
}
