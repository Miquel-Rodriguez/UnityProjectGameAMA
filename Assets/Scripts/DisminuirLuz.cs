using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisminuirLuz : MonoBehaviour
{

    void Update()
    {
       gameObject.GetComponent<Light>().intensity-=30f;
       if(gameObject.GetComponent<Light>().intensity==0){
            Destroy(gameObject);
       }
    }

}
