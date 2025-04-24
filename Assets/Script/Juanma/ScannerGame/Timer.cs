using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float maxTime = 30f;
    private float currentTime;
    public bool isRandom = false;

    public Slider timeSlider;

    void Start()
    {
        if (isRandom)
            maxTime = 20f;
        currentTime = maxTime;
        if (timeSlider != null)
            timeSlider.maxValue = maxTime;
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0f, maxTime);

        if (timeSlider != null)
            timeSlider.value = currentTime;

        if (currentTime <= 0)
        {
            Debug.Log("Se acabó el tiempo.");
            if (isRandom)
                if (ScoreManager.Instance.score > 150) {
                    loadNextSceneWin(isRandom);
                } else {
                    loadNextSceneLose(isRandom);
                }
            else {
                loseInfinity(ScoreManager.Instance.score);
            }
        }
    }

    public void AddTime(float timeToAdd)
    {
        currentTime += timeToAdd;
        currentTime = Mathf.Clamp(currentTime, 0f, maxTime);
        Debug.Log("Tiempo añadido: " + timeToAdd + " -> Tiempo actual: " + currentTime);
    }

    private void loadNextSceneLose(bool isRandom)
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        GestionSheep.loseAndGoingNextScene(isRandom);
    }

    private void loadNextSceneWin(bool isRandom)
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        GestionSheep.winAndGoingNextScene(isRandom);
    }

    public void loseInfinity(float point)
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        LeaderBoardGestions.activateLeaderBoardNotTime("ScanDB", (int)point);

    }
}
