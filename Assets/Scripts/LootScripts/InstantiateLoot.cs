using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLoot : MonoBehaviour
{

    public GameObject[] loots;


    public int[] probabilityTable =
    {
        60,30,10
    };
    int total;
    int randomNumber;
    void Start()
    {
       

    }


    public void InsantieteLoots()
    {
        foreach (var item in probabilityTable)
        {
            total += item;
        }

        randomNumber = Random.Range(0, total);

        for (int i = 0; i < probabilityTable.Length; i++)
        {
            if (randomNumber < probabilityTable[i])
            {

                Instantiate(loots[i], gameObject.transform.position, Quaternion.identity);
                return;
            }
            else
            {
                randomNumber -= probabilityTable[i];
            }
        }

    }

    void Update()
    {
        
    }
}
