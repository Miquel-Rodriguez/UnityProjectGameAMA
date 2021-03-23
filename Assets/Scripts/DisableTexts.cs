using System.Collections;
using UnityEngine;

public class DisableTexts : MonoBehaviour
{
    public void DisableIn(int segundos)
    {
        StartCoroutine(TiempoEspera(segundos));
    }

    private IEnumerator TiempoEspera(int segundos)
    {
        yield return new WaitForSeconds(segundos);
        gameObject.SetActive(false);
    }
}
