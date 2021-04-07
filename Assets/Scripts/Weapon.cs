using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapons", order = 1)]
public class Weapon : MonoBehaviour
{
    [SerializeField]
    protected string weaponName;
    [SerializeField]
    protected float reloadSpeed;
    [SerializeField]
    protected int capacityCharger;
    [SerializeField]
    protected float shootSpeed;
    [SerializeField]
    protected Transform shootPoint;

    protected float angleShootDirection;

    public bool reloading;
    protected Transform transformRotation;
    protected int bulletsCharge;

    protected float nextFireTime = 0;
    protected float nextReload = 0;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected GameObject bullet;
    [SerializeField]
    private int actualbullets;

    [SerializeField]
    protected float maxAngleVariationx;
    [SerializeField]
    protected float maxAngleVariationy;

    public bool isAvailable;

    public int Actualbullets { get => actualbullets; set => actualbullets = value; }

    public virtual IEnumerator Reload()
    {

        reloading = true;
        nextReload = Time.time + reloadSpeed;
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

        //mostrat bales totals 
        reloading = false;
    }

    protected void InstanceShoot()
    {
        float variationx = Random.Range(-maxAngleVariationy, maxAngleVariationy);
        float variationy = Random.Range(-maxAngleVariationx, maxAngleVariationx);


        shootPoint.rotation *= Quaternion.Euler(variationx, variationy, 1);

        GameObject go = Instantiate(bullet, shootPoint.position, Quaternion.Euler(transformRotation.rotation.eulerAngles.x + 90 + variationx, transformRotation.rotation.eulerAngles.y + variationy, 0));



        go.GetComponent<Rigidbody>().velocity = shootPoint.forward * speed;
        nextFireTime = Time.time + shootSpeed;
        shootPoint.rotation = Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y, 1);
    }

    protected void LessBullet()
    {
        bulletsCharge--;
    }

    protected void AddBullets(int bulletsToAdd)
    {
        actualbullets += bulletsToAdd;
    }



}
