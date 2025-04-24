using System.Collections;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class FireDugeonGameGestion : MonoBehaviour
{
    public GameObject[] list;

    public TextMeshProUGUI text;

    private string up = "m";
    private string down = ",";
    private string left = "b";
    private string right = "n";
    private string upRight = "c";
    private string upLeft = "v";
    private string downLeft = "x";
    private string downRight = "z";

    const int UP = 0;
    const int DOWN = 1;
    const int LEFT = 2;
    const int RIGHT = 3;
    const int UPLEFT = 4;
    const int UPRIGHT = 5;
    const int DOWNLEFT = 6;
    const int DOWNRIGHT = 7;

    public const int timePlay = 8;
    private const int maxTime = 10;
    private float time = 0;
    private int hardStyle = 0;

    public bool isInfinity = false;

    public bool isRandom;
    private FireDugeonController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        player = FindAnyObjectByType<FireDugeonController>();
        StartCoroutine(getPosition());
        StartCoroutine(disableText());
    }

    private IEnumerator disableText()
    {
        while (true)
        {

            if (Time.timeScale == 0) {
                text.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.4f);
            }
            else
            {
                text.gameObject.SetActive(true);
               
            }

            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
   
    private IEnumerator getPosition()
    {
        while(Time.timeScale == 0) yield return new WaitForSeconds(0.1f);

        hardStyle = 1 + (int)((Time.timeScale - 1) / 0.75);
        string movement = "";

        int x = 0;

        int positionX = 2;
        int positionY = 2;
        int dificult = 2 + (int)(Time.timeScale / 0.25) - hardStyle;
        while (x < dificult)
        {
            string addText = "";
            switch (nextNumber(positionX, positionY))
            {
                case UP:
                    positionY--;
                    addText = up;
                    break;
                
                case DOWN:
                    positionY++;
                    addText = down;
                    break;  
                
                case LEFT:
                    positionX--;
                    addText = left;
                    break;
                    
                case RIGHT:
                    positionX++;
                    addText = right;
                    break;
                case UPLEFT:
                    positionX--;
                    positionY--;
                    addText = upLeft;
                    hardStyle--;
                    break;
                case UPRIGHT:
                    positionX++;
                    positionY--;
                    addText = upRight;
                    hardStyle--;
                    break;
                case DOWNLEFT:
                    positionX--;
                    positionY++;
                    addText = downLeft;
                    hardStyle--;
                    break;
                case DOWNRIGHT:
                    positionX++;
                    positionY++;
                    addText = downRight;
                    hardStyle--;
                    break;

            }
                x++;
                movement += addText + "";
        }

        text.text = movement;
        GameObject gameObject = list[positionX + positionY * 5];
        Destroy(gameObject.GetComponent<FireDugeonFloorDestruction>());

    }
    
    private int nextNumber(int positionX, int positionY)
    {
        int x = 0;
        while (true)
        {
            if (hardStyle > 0)
            {
                x = Random.Range(0, 8);
            }
            else
            {
                x = Random.Range(0, 4);
            }
            if (positionX == 0 && (x == LEFT || x == UPLEFT || x == DOWNLEFT))
            {
                continue;
            }
            if (positionX == 4 && (x == RIGHT || x == UPRIGHT || x == DOWNRIGHT))
            {
                continue;
            }
            if (positionY == 0 && (x == UP || x == UPLEFT || x == UPRIGHT))
            {
                continue;
            }
            if (positionY == 4 && (x == DOWN || x == DOWNLEFT || x == DOWNRIGHT))
            {
                continue;
            }

            return x;
        }
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

            time += Time.deltaTime / Time.timeScale;
        

        if (time > maxTime)
        {
            if (isInfinity)
            {
                if (player.touchFireFloor)
                {
                    infinityMovementLose();
                }
                else
                {
                    infinityMovementVictory();
                }
            }
            else
            {
                if (player.touchFireFloor)
                {
                    GestionSheep.loseAndGoingNextScene(isRandom);
                }
                else
                {
                    GestionSheep.winAndGoingNextScene(isRandom);
                }
            }
        }
    }

    private void infinityMovementVictory()
    {
       Time.timeScale += 0.25f;
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void infinityMovementLose()
    {
        int point = (int)(Time.timeScale / 0.25f) - 4;
        Time.timeScale = 1;
        LeaderBoardGestions.activateLeaderBoardNotTime("BocataLomoYa", point);
    }

}
