using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialGestions : MonoBehaviour
{
    private float bufferTimeScale = 1;
    private CursorLockMode cursorStatus;
    public static bool isTutorialGestionEnable = false;
    private static string lastScene = "";

    public GameObject panel;

    private void Awake()
    {
        FindAnyObjectByType<PauseMenuScript>().tutorialObject = this;
        UnityEngine.SceneManagement.Scene actualScene = SceneManager.GetActiveScene();
        bufferTimeScale = Time.timeScale;
        cursorStatus = Cursor.lockState;
        if (lastScene == actualScene.name)
        {
            isTutorialGestionEnable = false;
            panel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            isTutorialGestionEnable = true;
            panel.SetActive(true);
        }
        lastScene = actualScene.name;
        
    }
    public void setConfiguration(float scaleTime, CursorLockMode statusCursor)
    {
        bufferTimeScale = scaleTime;
        cursorStatus = statusCursor;    
        isTutorialGestionEnable = true;
        panel.SetActive(true);
    }

    public void desactiveTutorial()
    {
        Time.timeScale = bufferTimeScale;
        Cursor.lockState = cursorStatus;
        isTutorialGestionEnable = false;
        panel.SetActive(false);
    }
}
