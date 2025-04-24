
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RandomGameController : MonoBehaviour
{
    public string[] scenes;

    private static List<int> bufferScenes = new List<int>();
    private static string mainScene = "ModeRandom";
    private static string mainMenu = "MenuSeleccion";
    private const int maxGame = 5;
    public void Start()
    {
        StartCoroutine(nextGame());
    }

    private IEnumerator nextGame()
    {
        yield return new WaitForSeconds(3f);
        if (bufferScenes.Count == maxGame)
        {
            SceneManager.LoadScene(mainMenu);
        }
        else
        {
            int nextGame = getNewNumber();
            SceneManager.LoadScene(scenes[nextGame]);
        }
           
    }

    private static void loadAtNotInfiniteMode()
    {
        bufferScenes = new List<int>();
        SceneManager.LoadScene(mainScene);
    }

    private int getNewNumber()
    {
        while (true)
        {
            int randomValue = Random.Range(0, scenes.Length);
            for(int x = 0; x < bufferScenes.Count; x++)
            {
                if(randomValue == bufferScenes[x])
                {
                    randomValue = -1;
                }
            }

            if (randomValue != -1)
            {
                bufferScenes.Add(randomValue);
                return randomValue;
            }

        }
    }

    public static void loadScene(string scene)
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(scene);
    }

    //private static void loadAtInfiniteMode()
    //{
    //    isInfiniteMode = true;
    //    bufferScenes = new List<int>();
    //    SceneManager.LoadScene(mainScene);
    //}

}
