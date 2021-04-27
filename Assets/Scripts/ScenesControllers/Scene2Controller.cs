using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene2Controller : MonoBehaviour
{
    private bool start = false;
    private bool isFadeIn = false;
    private float alpha = 0;
    private float fadeTime = 0.5f;
    private bool estadoStopMenu = true;
    private bool estadoHowPlay = true;

    private GameObject panel;
    private GameObject panelHow;
    private GameObject panelDead;
    [SerializeField] MoveGunWithMouse cameraMove;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && estadoHowPlay)
        {
            CambiarEstadoHoyToPlay();
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            CambiarEstadoStopMenu();
        }
    }
  
    public void CambiarEstadoHoyToPlay()
    {
        estadoHowPlay = !estadoHowPlay;
        panelHow.SetActive(estadoHowPlay);
    }


    private void Start()
    {
        panel = GameObject.Find("StopPlay").gameObject;
        panelHow = GameObject.Find("HowPlayPanel").gameObject;
        panelDead = GameObject.Find("DeadGUI").gameObject;
        CambiarEstadoStopMenu();
        CambiarEstadoHoyToPlay();
        panelDead.SetActive(false);
        StartCoroutine(GrowDawn());
    }

    public void CambiarEstadoStopMenu()
    {
        estadoStopMenu = !estadoStopMenu;
        if (cameraMove != null)
        {
            cameraMove.enabled = !estadoStopMenu;

        }
        panel.SetActive(estadoStopMenu);
        if (estadoStopMenu)
        {
            Time.timeScale = 0f;
        }
        else Time.timeScale = 1f;

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SceneSwitcher(int numScene)
    {
        Time.timeScale = 1f;
        StartCoroutine(Switch(numScene));
    }

    private IEnumerator Switch(int numScene)
    {
        FadeIn();
        yield return new WaitForSeconds(fadeTime + 1.5f);
        SceneManager.LoadScene(numScene);
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

    public void FadeIn()
    {
        start = true;
        isFadeIn = true;
    }

    public void FadeOut()
    {
        isFadeIn = false;
    }

    private IEnumerator GrowDawn()
    {
        alpha = 1;
        FadeIn();
        yield return new WaitForSeconds(fadeTime);
        fadeTime = 0.5f;
        FadeOut();
    }

    public IEnumerator ShowDeadGUI()
    {
        FadeIn();
        yield return new WaitForSeconds(1f);
        panelDead.SetActive(true);
        FadeOut();
        ///Desactivar TODO
    }
}

