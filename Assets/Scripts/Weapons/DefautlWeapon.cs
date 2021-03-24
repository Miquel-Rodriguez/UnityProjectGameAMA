using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefautlWeapon : Weapon
{
    // Start is called before the first frame update
    public void Start()
    {

        shootPoint = gameObject.GetComponentInChildren<Transform>();
        transformRotation = gameObject.GetComponent<Transform>();
        bulletsCharge = capacityCharger;
        
        SetTextAndImages();

        print("me he iniciado");
        StartCoroutine(AddOneBullet());
    }

    // Update is called once per frame
    public void Update()
    {
        if (bulletsCharge != 0)
        {
            if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime && !reloading)
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

        if (Input.GetKeyDown("r") && Time.time >= nextReload && actualbullets!=0)
        {
            StartCoroutine(Reload());
        }

    }
/*
    public override IEnumerator Reload()
    {
        reloading = true;
        nextReload = Time.time + reloadSpeed;
        print("reloading");
        yield return new WaitForSeconds(reloadSpeed);
        if (actualbullets < capacityCharger)
        {
            bulletsCharge = actualbullets;
            actualbullets = 0;
        }
        else
        {
            bulletsCharge = capacityCharger;
            actualbullets -= bulletsCharge;
        }
        print(actualbullets);
        //mostrat bales totals 
        reloading = false;
        textBulletsCharger.text = bulletsCharge.ToString();
        textTotalBullets.text = actualbullets.ToString();
        textReload.gameObject.SetActive(false);
    }
*/

    private IEnumerator AddOneBullet()
    {
        while (true)
        {
            print("hola?");
            if (actualbullets < 12)
            {
                actualbullets++;
                textTotalBullets.text = actualbullets.ToString();
            }
            yield return new WaitForSeconds(1);
        }

        
    }

}
