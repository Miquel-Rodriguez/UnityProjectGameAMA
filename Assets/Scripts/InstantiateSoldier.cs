using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSoldier : MonoBehaviour
{
    [SerializeField]
    private GameObject soldier;
    [SerializeField]
    private Transform PuntoTeletrasnporte;
    private GameObject soldierInstacniado;
    void Start()
    {
        soldierInstacniado = Instantiate(soldier, transform.position, Quaternion.identity);
        StartCoroutine(Transportar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Transportar()
    {
        yield return new WaitForSeconds(0.5f);
        soldierInstacniado.transform.position = PuntoTeletrasnporte.position;


    }
}
