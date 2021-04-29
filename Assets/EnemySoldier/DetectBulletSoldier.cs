﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBulletSoldier : MonoBehaviour
{

    [SerializeField] EnemySoldier enemySoldierScript;
    [SerializeField] int damage = 15;
    private void Start()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Bullet"))
        {
           enemySoldierScript.Lesslife(damage);
        }
    }


}
