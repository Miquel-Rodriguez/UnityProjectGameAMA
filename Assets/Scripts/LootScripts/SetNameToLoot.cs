using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNameToLoot : MonoBehaviour
{
    [SerializeField]
    private string lootName;
    void Start()
    {
        gameObject.name = lootName;
    }

}
