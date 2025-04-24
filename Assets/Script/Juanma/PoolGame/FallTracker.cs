using System.Collections;
using TMPro;
using UnityEngine;

public class FallTracker : MonoBehaviour
{
    private float startY;
    private float metersFallen;
    public bool isTracking = false;
    public TextMeshProUGUI metrosText;
    public InfiniteMode infiniteMode;

    void Start()
    {
        startY = transform.position.y;
        isTracking = true;
        StartCoroutine(disableText());
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if (isTracking)
        {
            float currentY = transform.position.y;
            metersFallen = Mathf.Max(0f, startY - currentY);
            metrosText.text = Mathf.FloorToInt(metersFallen) + "m";
        }
    }

    private IEnumerator disableText()
    {
        while (true)
        {

            if (Time.timeScale == 0)
            {
                metrosText.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                metrosText.gameObject.SetActive(true);

            }

            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    public void StopTracking(bool isRandom)
    {
        isTracking = false;
        if (infiniteMode.isInfinite)
        {
            infiniteMode.loseInfinity(metersFallen);
        } else {
            infiniteMode.loadNextSceneLoseJump(isRandom);
        }
        Debug.Log("Sobreviviste " + Mathf.FloorToInt(metersFallen) + " metros.");
    }

    public void StopTrackingWin(bool isRandom)
    {
        isTracking = false;
        infiniteMode.loadNextSceneWinJump(isRandom);
        Debug.Log("Sobreviviste " + Mathf.FloorToInt(metersFallen) + " metros.");
    }
}
