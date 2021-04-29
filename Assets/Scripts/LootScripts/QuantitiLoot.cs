using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantitiLoot : MonoBehaviour
{
    [SerializeField]int numQuantityLoot;

    public int NumQuantityLoot { get => numQuantityLoot; set => numQuantityLoot = value; }
}
