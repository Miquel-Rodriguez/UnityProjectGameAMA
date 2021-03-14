using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour
{
    [SerializeField]
    private int capacity;

    public int Capacity { get => capacity; set => capacity = value; }
}
