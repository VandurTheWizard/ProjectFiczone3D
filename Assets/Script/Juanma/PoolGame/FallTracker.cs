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
    }

    void Update()
    {
        if (isTracking)
        {
            float currentY = transform.position.y;
            metersFallen = Mathf.Max(0f, startY - currentY);
            metrosText.text = Mathf.FloorToInt(metersFallen) + "m";
        }
    }

    public void StopTracking()
    {
        isTracking = false;
        if (infiniteMode.isInfinite)
        {
            infiniteMode.loseInfinity(metersFallen);
        } else {
            infiniteMode.loadNextScene();
        }
        Debug.Log("Sobreviviste " + Mathf.FloorToInt(metersFallen) + " metros.");
    }
}
