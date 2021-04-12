using System.Collections;
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

    Weapon weaponScript;

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

    private Vector3 offset = new Vector3(0, 0.9f, 0);

    bool deadth;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!deadth)
        {
            enemyEyes.LookAt(player.position);
            transform.LookAt(playerContainer.position - offset);

            if (WatchingPlayer() && !shooting)
            {
                print("viendo");
                Shoot();
            }
            else if (!WatchingPlayer())
            {
                print("no veo nada");
                animator.SetBool("NormalShooting", false);
            }

            if (Time.time >= waitToDown && !down)
            {
                print("wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww");
                down = true;
                StartCoroutine(Down());
            }

            Debug.DrawRay(enemyEyes.position, enemyEyes.forward * visionRange, Color.red);
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
        enemyEyes.position = transform.position+new Vector3(0,1,0);
        animator.SetBool("NormalShooting", false);
        animator.SetBool("Down", true);
        waitToUp = Random.Range(minTimewaitToUp, maxTimeWaitToUp);
        yield return new WaitForSeconds(waitToUp);
        waitToDown = Time.time + Random.Range(minTimewaitwaitToDown, maxTimeWaitwaitToDown);
        animator.SetBool("Down", false);
        down = false;
        print("waite to dawn"+waitToDown);
        enemyEyes.position = transform.position + new Vector3(0, 1.75f, 0);
    }

    public IEnumerator Shooting()
    {
        timeShoot = Random.Range(minTimeShooting, maxTimeShooting);
        waiteToShoot = Random.Range(minTimewaitToShoot, maxTimeWaitToShoot);
        print("disparando");
        yield return new WaitForSeconds(timeShoot);
        animator.SetBool("NormalShooting", false);
        yield return new WaitForSeconds(waiteToShoot);
        shooting = false;

    }

/*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life -= 10;
            print(life + "collision");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            life -= 10;
            print(life + "trigger");
        }
    }
*/

    public void Lesslife(int damage)
    {
        life -= damage;
        print(life);
        if (life <= 0)
        {

            deadth = true;

            animator.SetBool("Die", true);
        }
    }
}
