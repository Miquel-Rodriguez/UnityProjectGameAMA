using System.Collections;
using UnityEngine;


public class DroneWeapon : EnemyWeapon
{

    public ParticleSystem particulaTiro;
    public bool disparar = true;

    RaycastHit hit;

    [SerializeField]
    Transform enemyEyes;

    [SerializeField]
    int visionRange;

    [SerializeField]
    Transform player;
    public void Start()
    {
        transformRotation = gameObject.GetComponent<Transform>();
        bulletsCharge = capacityCharger;

        StartCoroutine(AddOneBullet());
    }

    public void Update()
    {
        Debug.DrawRay(enemyEyes.position, enemyEyes.forward * visionRange, Color.red);
        RotateTowards(player, enemyEyes);
        if (bulletsCharge != 0)
        {
            if (Time.time >= nextFireTime && !reloading && WatchingPlayer())
            {


                InstanceShoot();
                disparo();
                LessBullet();


            }
        }

        if (bulletsCharge == 0 && Time.time >= nextReload && Actualbullets != 0)
        {
            StartCoroutine(Reload());
        }

    }

    private IEnumerator AddOneBullet()
    {
        while (true)
        {
            if (Actualbullets < 1)
            {
              



                Actualbullets =1;
            }
            yield return new WaitForSeconds(1);
        }


    }

    public void disparo()
    {
        particulaTiro.Play();
    }

    private bool WatchingPlayer()
    {

        return Physics.Raycast(enemyEyes.position, enemyEyes.forward, out hit, visionRange) && hit.collider.CompareTag("Player");

    }

    public static void RotateTowards(Transform player, Transform npc, float speed = 2.0f)
    {

        Vector3 direction = (player.position - npc.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        npc.rotation = Quaternion.Slerp(npc.rotation, lookRotation, Time.deltaTime * speed);

    }

}