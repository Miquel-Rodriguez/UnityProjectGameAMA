using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPack : MonoBehaviour
{
    [SerializeField] string bulletName;
    [SerializeField] int numBullets;

    public string BulletName { get => bulletName; set => bulletName = value; }
    public int NumBullets { get => numBullets; set => numBullets = value; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
