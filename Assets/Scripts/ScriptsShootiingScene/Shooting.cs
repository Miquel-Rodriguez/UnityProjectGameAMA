using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject[] weaponGun;

    [SerializeField]
    private Transform startPoint;

    private Transform transformRotation;
    private Weapons weapon;
    private int bullets;
    private int bulletsCharge;
    private float nextFireTime = 0;
    private float nextReload = 0;
    bool reloading;
    float pointx;
    float pointy;

    void Start()
    {
        weapon = weaponGun[0].GetComponent<Weapons>();
        bullets = weapon.MaxBullets;
        transformRotation = weaponGun[0].GetComponent<Transform>();
        //startPoint = weaponGun[0].GetComponentInChildren<Transform>();
        bulletsCharge = weapon.CapacityCharger;

         pointx = startPoint.rotation.eulerAngles.x;
         pointy = startPoint.rotation.eulerAngles.y;

    }

    // Update is called once per frame
    void Update()
    {


            if (bulletsCharge != 0)
            {
                if (Input.GetMouseButton(0) && Time.time >= nextFireTime && !reloading)
                {

                startPoint.rotation = Quaternion.Euler(pointx, pointy, 0);

                    GameObject go = Instantiate(bullet, startPoint.position, Quaternion.Euler(transformRotation.rotation.eulerAngles.x + 90, transformRotation.rotation.eulerAngles.y, 0));
              
                    go.GetComponent<Rigidbody>().velocity = startPoint.forward * speed;
                    nextFireTime = Time.time + weapon.ShotSpeed;
                    bulletsCharge--;

                startPoint.rotation = Quaternion.Euler(pointx, pointy, 0);

                //indicar les bales que falten

            }
        }
            else if (bullets != 0)
            {
                //posar text de recarga
                print("has de recargar");
            }
            else
            {
                //posar text on indica que no hi han bales
                print("No hi han bales");
                print(bullets);
            }


            if (Input.GetKeyDown("r") && Time.time >= nextReload)
            {
                StartCoroutine(Reload());
            }



        
    }
    
    public IEnumerator Reload()
    {
        reloading = true;
        nextReload = Time.time + weapon.ReloadSpeed;
        print("reloading");
        yield return new WaitForSeconds(weapon.ReloadSpeed);
        bulletsCharge = weapon.CapacityCharger;
        bullets -= bulletsCharge;
        print(bullets);
        //mostrat bales totals 
        reloading = false;
    }
}
