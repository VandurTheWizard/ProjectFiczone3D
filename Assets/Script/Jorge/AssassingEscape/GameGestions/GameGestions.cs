using UnityEngine;

public class GameGestions : MonoBehaviour
{
    private int ninjas = 3;
    private int ninjaFind = 0;

    private ControllerGame controller;

    private float time = 0;
    private float maxTime = 10;

    public GameObject[] gameObjects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enableGame();
        controller = GameObject.FindAnyObjectByType<ControllerGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ninjaFind == ninjas)
        {
            controller.Victory();
        }

        time += Time.deltaTime;

        if(time > maxTime)
        {
            controller.Lose();
        }
        
    }

    public void enableGame()
    {
        int x = 0;
        while (x < ninjas) {
            int random = Random.Range(0, gameObjects.Length);
            if (!gameObjects[random].activeSelf)
            {
                gameObjects[random].SetActive(true);
                x++;
            }
            
        }
       
    }


    public void findNinja()
    {
        ninjaFind++;
    }
}
