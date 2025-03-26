using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerGame : MonoBehaviour
{
    public int[] microgameScenes;
    public int baseScene;
    public int loseScene;
    private Coroutine coroutine;

    private int status = 0;
    private const int WAIT = 0;
    private const int VICTORY = 1;
    private const int LOSE = 2;

    private float waitTime = 0.1f;

    private int life = 5;
    private int point = 0;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        
    }


    private void Update()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(TheSceneIsOver());
        }
    }

    private IEnumerator TheSceneIsOver()
    {

        yield return new WaitForSeconds(waitTime * 30);
        loadScene();

        while (status == WAIT) yield return new WaitForSeconds(waitTime);

        switch (status)
        {
            case VICTORY:
                point++;
                break;
            case LOSE:
                life--;
                break;
        }
        status = WAIT;
        SceneManager.LoadScene(baseScene);
        coroutine = null;
        
    }

    private void loadScene()
    {
        SceneManager.LoadScene(microgameScenes[Random.Range(0, microgameScenes.Length)]);
    }

    public void Lose()
    {
        status = LOSE;
    }

    public void Victory()
    {
        status = VICTORY;
    }

}
