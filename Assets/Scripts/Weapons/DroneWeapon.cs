using System.Collections;
using UnityEngine;


public class DroneWeapon : EnemyWeapon
{

    public ParticleSystem particulaTiro;

    public void Start()
    {
        transformRotation = gameObject.GetComponent<Transform>();
        bulletsCharge = capacityCharger;

        StartCoroutine(AddOneBullet());
    }

    public void Update()
    {
        if (bulletsCharge != 0)
        {
            if ( Time.time >= nextFireTime && !reloading)
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
                Actualbullets=1;
            }
            yield return new WaitForSeconds(1);
        }


    }

    private void disparo()
    {
        particulaTiro.Play();
    }

}