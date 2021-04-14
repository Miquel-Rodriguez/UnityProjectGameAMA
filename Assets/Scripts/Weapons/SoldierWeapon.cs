using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierWeapon : EnemyWeapon
{
    [SerializeField]
    private ParticleSystem particulaTiro;

    public bool disparar;

    private void Update()
    {
        if(disparar && Time.time >= nextFireTime)
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
