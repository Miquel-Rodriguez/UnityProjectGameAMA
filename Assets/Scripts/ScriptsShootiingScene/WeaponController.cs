using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject [] weapons;

    private List<GameObject> WeaponsPlayerGet;
    Weapon weponScript;
    int index=0;
    Vector3 weaponTransform;
    public void Start()
    {
        weponScript = weapons[index].GetComponent<Weapon>();
        weponScript.isAvailable = true;
    }

    public void ActiveWeapon(int side)
    {
        weponScript = weapons[side].GetComponent<Weapon>();
        weponScript.isAvailable = true;

    }

    public void Update()
    {
        if (Input.GetKeyDown("a"))
        {

            weponScript = weapons[index].GetComponent<Weapon>();
            if (!weponScript.reloading)
            {
                weapons[index].SetActive(false);
                weaponTransform = weapons[index].GetComponent<Transform>().rotation.eulerAngles;
                print("previa"+weapons[index].GetComponent<Transform>().rotation);
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

        weponScript = weapons[index].GetComponent<Weapon>();
        weponScript.isAvailable = true;
        if (weponScript.isAvailable)
        {
            
            weapons[index].SetActive(true);
            //weapons[index].GetComponent<Transform>().rotation = Quaternion.Euler(weaponTransform.x,weaponTransform.y,weaponTransform.z);
            print(weapons[index].GetComponent<Transform>().rotation.x);
            //weapons[index].GetComponent<Transform>().rotation = Quaternion.Euler(30,30,30);

            print(weapons[index].GetComponent<Transform>().rotation.x);

            weponScript.SetTextAndImages();
        }
        else changeWepoan();
    }
}
