using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefautlWeapon : Weapon
{
    // Start is called before the first frame update
    public void Start()
    {


        transformRotation = gameObject.GetComponent<Transform>();
        bulletsCharge = capacityCharger;
        
        SetTextAndImages();

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
                gameObject.GetComponent<Weapon>().disparo();
                LessBullet();

            }
        }
        else if (Actualbullets != 0)
        {
            textReload.gameObject.SetActive(true);
        }
        else
        {
            //posar text on indica que no hi han bales
            print("No hi han bales");
            print(Actualbullets);
        }

        if (Input.GetKeyDown("r") && Time.time >= nextReload && Actualbullets != 0)
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
            if (Actualbullets < 12)
            {
                Actualbullets++;
                textTotalBullets.text = Actualbullets.ToString();
            }
            yield return new WaitForSeconds(1);
        }

        
    }

}
