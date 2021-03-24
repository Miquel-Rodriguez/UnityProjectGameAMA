using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondWeapon : Weapon
{
    public void Start()
    {

        shootPoint = gameObject.GetComponentInChildren<Transform>();
        transformRotation = gameObject.GetComponent<Transform>();
        bulletsCharge = capacityCharger;

        SetTextAndImages();

        print("me he iniciado");
    }

    // Update is called once per frame
    public void Update()
    {
        if (bulletsCharge != 0)
        {
            if (Input.GetMouseButton(0) && Time.time >= nextFireTime && !reloading)
            {
                InstanceShoot();
                LessBullet();

            }
        }
        else if (actualbullets != 0)
        {
            textReload.gameObject.SetActive(true);
        }
        else
        {
            //posar text on indica que no hi han bales
            print("No hi han bales");
            print(actualbullets);
        }

        if (Input.GetKeyDown("r") && Time.time >= nextReload && actualbullets != 0)
        {
            StartCoroutine(Reload());
        }
    }
}
