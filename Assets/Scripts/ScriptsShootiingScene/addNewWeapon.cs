using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addNewWeapon : MonoBehaviour
{
    [SerializeField]
    private int index;
    [SerializeField]
    private WeaponController weaponController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        weaponController.ActiveWeapon(index);
    }
}
