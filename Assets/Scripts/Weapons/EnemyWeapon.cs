using System.Collections;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyWeapon", menuName = "ScriptableObjects/EnemyWeapons", order = 1)]
public class EnemyWeapon : MonoBehaviour
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
    protected GameObject bullet;
    [SerializeField]
    private int actualbullets;

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

        reloading = false;
    }

    protected void InstanceShoot()
    {
        GameObject go = Instantiate(bullet, shootPoint.position, Quaternion.Euler(transformRotation.rotation.eulerAngles.x + 90 , transformRotation.rotation.eulerAngles.y , 0));
        nextFireTime = Time.time + shootSpeed;
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
