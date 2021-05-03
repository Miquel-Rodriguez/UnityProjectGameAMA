using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialSceneController : MonoBehaviour
{

    private bool start = false;
    private bool isFadeIn = false;
    private float alpha = 0;
    private float fadeTime = 0.5f;

    private GameObject panel;

    private void Start()
    {
        panel = GameObject.Find("HowPlayPanel").gameObject;
        CerrarHowPlay();
        StartCoroutine(GrowDawn());
        Cursor.visible = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SceneSwitcher(int numscene)
    {
        StartCoroutine(Switch(numscene));
    }

    private IEnumerator Switch(int numscene)
    {
        FadeIn();
        yield return new WaitForSeconds(fadeTime + 1.5f);
        SceneManager.LoadScene(1);
        FadeOut();
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




    public void CerrarHowPlay()
    {
        panel.SetActive(false);
    }

    public void AbrirHowPlay()
    {
        panel.SetActive(true);
    }

}
