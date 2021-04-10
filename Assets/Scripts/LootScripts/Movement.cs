using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public List<Text> listaTextos;


    // Start is called before the first frame update
    void Start()
    {
        foreach(var texto in listaTextos)
        {
            texto.gameObject.SetActive(false);
        }
    }


    public void ShowMessage(string nombre)
    {
        foreach(var texto in listaTextos)
        {
            if (!texto.gameObject.activeSelf)
            {
                texto.gameObject.SetActive(true);
                texto.text = "Has obtenido: " + nombre;
                DisableTexts disable = texto.GetComponent<DisableTexts>();
                disable.DisableIn(3);
                break;
            }
        }
    }
}
