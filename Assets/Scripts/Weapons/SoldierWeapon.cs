using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierWeapon : EnemyWeapon
{
    [SerializeField]
    private ParticleSystem particulaTiro;

    public bool disparar;
    public float waitToShoot; 

    private void Update()
    {
        if(disparar && Time.time >= nextFireTime && Time.time >= waitToShoot)
        {
            Shoot();
        }
    }

    public void Shoot()
    {

        print("paso por aqí");
        InstanceShoot();
        ParticulaDisparo();

    }

    private void ParticulaDisparo()
    {
        particulaTiro.Play();
    }
}
