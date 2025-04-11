using System.Collections;
using UnityEngine;

public class IngredientCntroller : MonoBehaviour
{
    private bool canCount = true;
    //private int score = 3; //0 fail, 1 good, 2 perfect
    private bool scoreSent = false;

    private float time = 0;

    private void Update()
    {
    }

    private void Start()
    {
        transform.GetComponent<Collider>().enabled = false;
    }
    private int score = 3;
    public int Score
    {
        get { return score; }
        set
        {
            Debug.Log("a");
            if (score == value) return;
            if (value == 0)
                GameObject.Find("Generator").gameObject.GetComponent<BurguerController>().NextIngredient();
            else
            {

                Debug.Log("empece coroutina");
                StartCoroutine(TouchedSomething());
                Debug.Log("acabe coroutina");
            }
            Debug.Log("value");
            score = value;
        }
    }


    private void VariableChangeHandler(int newVal)
    {
        Debug.Log("testing");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Table"))
        {
            Score = 0;
            Debug.Log("FAIL");
            transform.GetComponent<Collider>().enabled = false;
        }

        if (other.CompareTag("Ingredient"))
        {
            //canCount = true;

            //Compare current position with position of below object
            float distance = transform.position.x - other.transform.position.x;
            if (distance < 0.1f)
            {
                Score = 2;
                Debug.Log("PERFECT");
            }
            else
            {
                Score = 1;
                Debug.Log("1");
            }

            // if(canCount) StartCoroutine(TouchedSomething());
        }


    }
    IEnumerator TouchedSomething()
    {
        canCount = false;
        yield return new WaitForSeconds(.7f);

        if (score != 0)
        {
           
            Debug.Log("me quede fuerte");
            GameObject.Find("Generator").GetComponent<BurguerController>().NextIngredient();
            transform.GetComponent<Collider>().enabled = false;
        }
    }

    private void SendScore()
    {
        scoreSent = true;
        Debug.Log("ScoreEnviado");
    }

    /*
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingredient"))
        {
            //Compare current position with position of below object
            float distance = transform.position.x - other.transform.position.x;
            if (distance < 0.1f)
            {
                score = 2;
                Debug.Log("PERFECT");
            }
            else
            {
                score = 1;
                Debug.Log("good?");
            }
            canCount = true;
        }
        if (other.CompareTag("Table"))
        {
            //Table canCount, score ended
            score = 0;
            Debug.Log("FAIL");
            SendScore();
        }
    }

    int stayCount = 0;
    private void OnTriggerStay(Collider other)
    {
        //Conditions: score wasnt sent, it has a limit stay time
        //When its a good score and table wasnt canCount
        if (!scoreSent && time>1f && other.CompareTag("Ingredient"))
        {
            Debug.Log("im good");
            SendScore();
        }
    }

   */

}