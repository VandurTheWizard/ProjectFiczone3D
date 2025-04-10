using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class FireDugeonGameGestion : MonoBehaviour
{
    public GameObject[] list;

    public TextMeshProUGUI text;

    private string up = " \u2191";
    private string down = " \u2193";
    private string left = "\u2190";
    private string right = " \u2192";

    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        getPosition();
    }



    private void getPosition()
    {
        const int UP = 0;
        const int DOWN = 1;
        const int LEFT = 2;
        const int RIGHT = 3;

        string movement = "SafeZone: ";

        int x = 0;

        int positionX = 2;
        int positionY = 2;

        int dificult = 2 + (int)(Time.timeScale / 0.25);
        while (x < dificult)
        {
            string addText = "";
            switch (Random.Range(0, 4))
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
            }
            if (positionX < 0 || positionX > 4 || positionY < 0 || positionY > 4)
            {
                if (positionX < 0 || positionX > 4)
                {
                    positionX = (positionX < 0) ? 0 : 4;
                }
                else
                {
                    positionY = (positionY < 0) ? 0 : 4;
                }
            }
            else
            {
                Debug.Log(positionX +"," +positionY );
                x++;
                movement += addText + " ";
            }
        }

        text.text = movement;
        GameObject gameObject = list[positionX + positionY * 5];
       Destroy(gameObject.GetComponent<FireDugeonFloorDestruction>());

    }

}
