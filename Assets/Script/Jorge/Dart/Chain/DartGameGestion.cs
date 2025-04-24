using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DartGameGestion : MonoBehaviour
{
    public GameObject dart;
    public Vector3 dartPosition;

    public GameObject[] goodChain;
    public GameObject[] badChain;
    private bool[] isUsable;

    public TextMeshProUGUI text;

    public int point = 0;

    public int life = 0;
    public bool isInfinite = false;
    public bool isRandom = false;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextDart();
        isUsable = new bool[goodChain.Length];
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(isPointEnable());

    }

    private IEnumerator isPointEnable()
    {
        while (true)
        {
            if (Time.deltaTime == 0)
            {
                text.gameObject.SetActive(false);
            }
            else
            {
                text.gameObject.SetActive(true);
            }
            yield return new WaitForSecondsRealtime(0.1f);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        else
        {
            Time.timeScale = 3 + point / 100 * 0.20f;
        }
           
        if (life <= 0)
        {
            if (isInfinite)
            {
                loseInfinite();
            }
            else
            {
                loseWinNormal();
            }
                
            return;
        }
        if(point > 500 && !isInfinite)
        {
            loseWinNormal();
        }
        for (int i = 0; i < isUsable.Length; i++)
        {
            if (!isUsable[i])
            {
                isUsable[i] = true;
                if (Random.Range(0, 2) == 0)
                {
                    StartCoroutine(generateChain(badChain[i]));
                }
                else
                {
                    StartCoroutine(generateChain(goodChain[i]));
                }
            }
        }
        text.text = "Tus puntos: " + point + "\nVidas restantes:" + life;

    }

    private IEnumerator generateChain(GameObject chain)
    {
        yield return new WaitForSeconds(Random.Range(0, 5));
        Instantiate(chain);

    }

    public void nextDart()
    {
        GameObject dart = Instantiate(this.dart, dartPosition, Quaternion.identity);
        dart.GetComponent<DartScript>().gestion = this;
        

    }
   

    public void changeUsable(int usable)
    {
        isUsable[usable] = false;
    }

    private void loseInfinite()
    {
        Time.timeScale = 1;
        LeaderBoardGestions.activateLeaderBoardNotTime("Dart", point);
    }


    private void loseWinNormal()
    {
        if(life <= 0)
        {
            GestionSheep.loseAndGoingNextScene(isRandom);
        }
        else
        {
            GestionSheep.winAndGoingNextScene(isRandom);
        }
 
    }
}
