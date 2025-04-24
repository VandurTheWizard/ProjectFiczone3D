using System.Collections;
using UnityEngine;

public class GestionSheep : MonoBehaviour
{
    private AnimacionesFinPartida sheepAnimations;
    private bool isEnded = false;
    private const string mainMenu = "MenuSeleccion";
    private const string randomMode = "ModeRandom";
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        sheepAnimations = GetComponent<AnimacionesFinPartida>();
        isEnded = false;
    }
     
    public void win(bool isRandomMode)
    {
        if (isEnded)
        {
            return;
        }
        activate();
        sheepAnimations.AnimacionGanadora();
        StartCoroutine(nextScene(isRandomMode));
    }

    public void lose(bool isRandomMode)
    {
        if (isEnded)
        {
            return;
        }
        activate();
        sheepAnimations.AnimacionPerdedora();
        StartCoroutine(nextScene(isRandomMode));
    }

    private void activate()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isEnded = true;
        gameObject.SetActive(true);
    }

    public static void winAndGoingNextScene(bool isRandomMode)
    {
        GameObject.FindAnyObjectByType<GestionSheep>().win(isRandomMode);
    }

    public static void loseAndGoingNextScene(bool isRandomMode)
    {
        GameObject.FindAnyObjectByType<GestionSheep>().lose(isRandomMode);
    }

    public IEnumerator nextScene(bool isRandomMode)
    {
        yield return new WaitForSeconds(2f);
        if (isRandomMode)
        {
            
            RandomGameController.loadScene(randomMode);
        }
        else
        {
            
            RandomGameController.loadScene(mainMenu);
        }
        

    }
}
