using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float maxTime = 30f;
    private float currentTime;

    public Slider timeSlider;

    void Start()
    {
        currentTime = maxTime;
        if (timeSlider != null)
            timeSlider.maxValue = maxTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0f, maxTime);

        if (timeSlider != null)
            timeSlider.value = currentTime;

        if (currentTime <= 0)
        {
            Debug.Log("Se acabó el tiempo.");
            // Aquí puedes poner el Game Over o lo que quieras.
        }
    }

    public void AddTime(float timeToAdd)
    {
        currentTime += timeToAdd;
        currentTime = Mathf.Clamp(currentTime, 0f, maxTime);
        Debug.Log("Tiempo añadido: " + timeToAdd + " -> Tiempo actual: " + currentTime);
    }
}
