using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weapons;

    private List<GameObject> WeaponsPlayerGet;
    private Weapon weponScript;
    int index = 0;
    Vector3 weaponTransform;

    public Weapon WeponScript { get => weponScript; set => weponScript = value; }

    public void Start()
    {
        WeponScript = weapons[index].GetComponent<Weapon>();
        WeponScript.isAvailable = true;
    }

    public void ActiveWeapon(int side)
    {
        WeponScript = weapons[side].GetComponent<Weapon>();
        WeponScript.isAvailable = true;

    }

    public void Update()
    {
        if (Input.GetKeyDown("a"))
        {

            WeponScript = weapons[index].GetComponent<Weapon>();
            if (!WeponScript.reloading)
            {
                weapons[index].SetActive(false);
                weaponTransform = weapons[index].GetComponent<Transform>().rotation.eulerAngles;
                print("previa" + weapons[index].GetComponent<Transform>().rotation);
                changeWepoan();
            }


        }
    }

    public void changeWepoan()
    {
        if (index + 1 < weapons.Length)
        {
            index++;
        }
        else index = 0;

        WeponScript = weapons[index].GetComponent<Weapon>();
        WeponScript.isAvailable = true;
        if (WeponScript.isAvailable)
        {

            weapons[index].SetActive(true);
            print(weapons[index].GetComponent<Transform>().rotation.x);

            print(weapons[index].GetComponent<Transform>().rotation.x);

        }
        else changeWepoan();
    }
}