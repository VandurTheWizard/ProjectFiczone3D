using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    private float bufferTimeScale = 1;
    private CursorLockMode cursorStatus;
    private bool cursorEnable;

    private PlayerInput objetoDeRespaldo;
    public TutorialGestions tutorialObject;
    public GameObject buttonTutorial;

    public GameObject panel;

    private static string mainMenu = "MenuSeleccion";
    

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
            cursorEnable = Cursor.visible;
            Cursor.visible = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            comprobeIfTutorialExist();
            panel.SetActive(true);
        }
        else
        {
            Time.timeScale = bufferTimeScale;
            Cursor.lockState = cursorStatus;
            Cursor.visible = cursorEnable;
            panel.SetActive(false);
        }
            
    }
    
    public void showTheTutorial()
    {
        tutorialObject.gameObject.SetActive(true);
        tutorialObject.setConfiguration(bufferTimeScale, cursorStatus, cursorEnable);
        panel.SetActive(false);
    }

    public void keepSleeping()
    {
        Time.timeScale = bufferTimeScale;
        Cursor.lockState = cursorStatus;
        Cursor.visible = cursorEnable;
        panel.SetActive(false);
    }

    public void backToMenu()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(mainMenu);
        panel.SetActive(false);
    }

}
