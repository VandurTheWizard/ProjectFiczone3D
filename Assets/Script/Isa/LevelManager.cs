using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private TextMeshProUGUI textCountdown;
    [SerializeField] private Canvas canvas;
    float counter;

    private void Awake()
    {
        if (Instance != null && Instance != this) { }
        else Instance = this;
    }

    private void Start()
    {
        canvas.enabled = true;
        textCountdown.text = "3";
        counter = 4;
    }

    private void Update()
    {
        if (counter > 0)
        {
            counter = counter - Time.deltaTime;
            textCountdown.text = Mathf.Floor(counter).ToString();
        }
        else
        {
            canvas.enabled = false;
        }
    }
}
