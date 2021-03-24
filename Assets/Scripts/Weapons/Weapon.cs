using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

    [SerializeField]
    Transform padre;

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
    protected int actualbullets;

    [SerializeField]
    protected float maxAngleVariationx;
    [SerializeField]
    protected float maxAngleVariationy;

    [SerializeField]
    protected Text textBulletsCharger;
    [SerializeField]
    protected Text textTotalBullets;
    [SerializeField]
    protected Text textWaponName;
    [SerializeField]
    protected Text textReload;
    [SerializeField]
    protected Sprite weaponImage;
    [SerializeField]
    protected Image imageWeaponImage;
    public bool isAvailable;

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
        textBulletsCharger.text = bulletsCharge.ToString();
        textTotalBullets.text = actualbullets.ToString();
        textReload.gameObject.SetActive(false);
    }

    protected void InstanceShoot()
    {
       //  shootPoint.GetComponentInParent<Transform>().position = padre.position;
       //  shootPoint.GetComponentInParent<Transform>().rotation = padre.rotation;

       // shootPoint.GetComponent<Transform>().rotation = padre.rotation;

        float variationx= Random.Range(-maxAngleVariationy, maxAngleVariationy);
        float variationy= Random.Range(-maxAngleVariationx, maxAngleVariationx);

       // shootPoint.rotation = Quaternion.Euler(shootPoint.rotation.eulerAngles.x, shootPoint.rotation.eulerAngles.y, 0 );

        shootPoint.rotation *= Quaternion.Euler(variationx,variationy,1);

        GameObject go = Instantiate(bullet, shootPoint.position, Quaternion.Euler(transformRotation.rotation.eulerAngles.x + 90 +variationx, transformRotation.rotation.eulerAngles.y+variationy, 0));



        go.GetComponent<Rigidbody>().velocity = shootPoint.forward * speed;
        nextFireTime = Time.time + shootSpeed;
        shootPoint.rotation = Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y, 1);
        //indicar les bales que falten
    }

    protected void LessBullet()
    {
        bulletsCharge--;
        textBulletsCharger.text = bulletsCharge.ToString();
    }

    protected void AddBullets(int bulletsToAdd)
    {
        actualbullets += bulletsToAdd;
        textTotalBullets.text = actualbullets.ToString();
    }

    public void SetTextAndImages()
    {
           textBulletsCharger.text = bulletsCharge.ToString();
           textTotalBullets.text = actualbullets.ToString();
           textWaponName.text = weaponName;
           textReload.gameObject.SetActive(false);
           imageWeaponImage.sprite = weaponImage;
    }


}
