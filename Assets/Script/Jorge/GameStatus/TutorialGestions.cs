using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialGestions : MonoBehaviour
{
    private float bufferTimeScale = 1;
    private CursorLockMode cursorStatus;
    public static bool isTutorialGestionEnable = false;
    private static string lastScene = "";
    private bool cursorVisible = true;


    public GameObject panel;

    private Coroutine coroutine;

    private void Awake()
    {
        FindAnyObjectByType<PauseMenuScript>().tutorialObject = this;
        UnityEngine.SceneManagement.Scene actualScene = SceneManager.GetActiveScene();
        bufferTimeScale = Time.timeScale;
        cursorStatus = Cursor.lockState;
        cursorVisible = Cursor.visible;
        if (lastScene == actualScene.name)
        {
            isTutorialGestionEnable = false;
            panel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isTutorialGestionEnable = true;
            panel.SetActive(true);
        }
        lastScene = actualScene.name;
       coroutine = StartCoroutine(getCursor());
        
    }

    private IEnumerator getCursor()
    {
        while (true)
        {
            if(Cursor.lockState != CursorLockMode.None || !Cursor.visible)
            {
                cursorStatus = Cursor.lockState;
                cursorVisible = Cursor.visible;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }

    }
    public void setConfiguration(float scaleTime, CursorLockMode statusCursor, bool isCursorVisible)
    {
        bufferTimeScale = scaleTime;
        cursorStatus = statusCursor;
        cursorVisible = isCursorVisible;
        isTutorialGestionEnable = true;
        panel.SetActive(true);
    }

    public void desactiveTutorial()
    {
        StopCoroutine(coroutine);
        Time.timeScale = bufferTimeScale;
        Cursor.lockState = cursorStatus;
        Cursor.visible = cursorVisible;
        isTutorialGestionEnable = false;
        panel.SetActive(false);
    }
}
