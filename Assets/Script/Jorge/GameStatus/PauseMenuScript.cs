using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    private float bufferTimeScale = 1;
    private CursorLockMode cursorStatus;

    private PlayerInput objetoDeRespaldo;
    public TutorialGestions tutorialObject;
    public GameObject buttonTutorial;

    public GameObject panel;

    private static string mainMenu = "";
    

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        addMenu(); 
        panel.SetActive(false);
    }

    private void Update()
    {
        if(objetoDeRespaldo == null){
            addMenu();
        }
    }

    private void comprobeIfTutorialExist()
    {
        if(tutorialObject == null)
        {
            buttonTutorial.SetActive(false);
        }
        else
        {
            buttonTutorial.SetActive(true);
        }
    }

    private void addMenu()
    {
        
        objetoDeRespaldo = FindAnyObjectByType<PlayerInput>();

        if (objetoDeRespaldo != null)
        {
            objetoDeRespaldo.gameObject.AddComponent<PauseMenuActivation>();
            objetoDeRespaldo.GetComponent<PauseMenuActivation>().pauseMenu = this;
        }
    }


   

    public void upMenu()
    {
        if (!panel.activeSelf)
        {
            bufferTimeScale = Time.timeScale;
            cursorStatus = Cursor.lockState;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            comprobeIfTutorialExist();
            panel.SetActive(true);
        }
        else
        {
            Time.timeScale = bufferTimeScale;
            Cursor.lockState = cursorStatus;
            panel.SetActive(false);
        }
            
    }
    
    public void showTheTutorial()
    {
        tutorialObject.gameObject.SetActive(true);
        tutorialObject.setConfiguration(bufferTimeScale, cursorStatus);
        panel.SetActive(false);
    }

    public void keepSleeping()
    {
        Time.timeScale = bufferTimeScale;
        Cursor.lockState = cursorStatus;
        panel.SetActive(false);
    }

    public void backToMenu()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(mainMenu);
        panel.SetActive(false);
    }

}
