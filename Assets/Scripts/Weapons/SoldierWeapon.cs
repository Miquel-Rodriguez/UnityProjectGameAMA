using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierWeapon : EnemyWeapon
{
    [SerializeField]
    private ParticleSystem particulaTiro;

    public bool disparar;
    public float waitToShoot;
    public bool flashed;
    private void Update()
    {
        if(disparar && Time.time >= nextFireTime && Time.time >= waitToShoot && !flashed)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if(Random.Range(1,4) == 1)
        {
            InstanceShoot();
        }


        ParticulaDisparo();

    }

    private void ParticulaDisparo()
    {
        particulaTiro.Play();
    }


}
