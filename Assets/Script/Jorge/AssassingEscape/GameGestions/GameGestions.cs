using UnityEngine;

public class GameGestions : MonoBehaviour
{
    private int ninjas = 3;
    private int ninjaFind = 0;

    private float time = 0;
    private float maxTime = 10;

    public GameObject[] gameObjects;
    public bool isRandom = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enableGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if (ninjaFind == ninjas)
        {
            GestionSheep.winAndGoingNextScene(isRandom);
        }

        time += Time.deltaTime / Time.timeScale;

        if(time > maxTime)
        {
            GestionSheep.loseAndGoingNextScene(isRandom);
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
