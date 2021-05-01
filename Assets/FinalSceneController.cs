using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalSceneController : MonoBehaviour
{

    private bool start = false;
    private bool isFadeIn = false;
    private float alpha = 0;
    private float fadeTime = 0.5f;

    private GameObject panel;

    [SerializeField] RawImage textImage1;
    [SerializeField] RawImage textImage2;
    [SerializeField] RawImage textImage3;


    private void Start()
    {


        textImage2.enabled = false;
        textImage3.enabled = false;
        StartCoroutine(ElFinal());
        StartCoroutine(GrowDawn());
    }

    private IEnumerator ElFinal()
    {
        yield return new WaitForSeconds(4.5f);
        FadeIn();
        yield return new WaitForSeconds(1f);
        textImage1.enabled = false;
        textImage2.enabled = true;
        FadeOut();
        yield return new WaitForSeconds(4.5f);
        FadeIn();
        yield return new WaitForSeconds(1f);
        textImage2.enabled = false;
        textImage3.enabled = true;
        FadeOut();
        yield return new WaitForSeconds(6.5f);
        FadeIn();
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(0);

    }


    private IEnumerator GrowDawn()
    {
        alpha = 1;
        FadeIn();
        yield return new WaitForSeconds(fadeTime);
        fadeTime = 0.5f;
        FadeOut();
    }




    private void OnGUI()
    {
        if (!start)
            return;

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        Texture2D tex;
        tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, Color.black);
        tex.Apply();

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex);

        if (isFadeIn)
        {
            alpha = Mathf.Lerp(alpha, 2.1f, fadeTime * Time.deltaTime);

        }
        else
        {
            alpha = Mathf.Lerp(alpha, -0.1f, fadeTime * Time.deltaTime);
            if (alpha < 0) start = false;
        }
    }

    private void FadeIn()
    {
        start = true;
        isFadeIn = true;
    }

    private void FadeOut()
    {
        isFadeIn = false;
    }
}
