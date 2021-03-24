using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField]
    private int maxBullets;
    [SerializeField]
    private int capacityCharger;
    [SerializeField]
    private float shotSpeed;
    [SerializeField]
    private float reloadSpeed;


    public int MaxBullets { get => maxBullets; set => maxBullets = value; }

    public float ShotSpeed { get => shotSpeed; set => shotSpeed = value; }
    public float ReloadSpeed { get => reloadSpeed; set => reloadSpeed = value; }
    public int CapacityCharger { get => capacityCharger; set => capacityCharger = value; }
}
