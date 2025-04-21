using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DartGameGestion : MonoBehaviour
{
    public GameObject dart;
    public Vector3 dartPosition;

    public GameObject[] goodChain;
    public GameObject[] badChain;
    private bool[] isUsable;

    public int point = 0;

    public int life = 0;
    public bool isInfinite = false;
    public string nextScene = "";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextDart();
        isUsable = new bool[goodChain.Length];

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 3 + point / 100 * 0.20f;
        if (life == 0)
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
        RandomGameController.loadScene(nextScene);
    }
}
