using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI textCountdown;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject panelStart;


    [Header("Sound")]
    [SerializeField] private AudioSource music;

    [HideInInspector] public bool playing = false;
    private float counter;

    private void Awake()
    {
        if (Instance != null && Instance != this) { }
        else Instance = this;
    }

    private void Start()
    {
        panelStart.SetActive(true);
        textCountdown.text = "3";
        counter = 3;
    }

    private void Update()
    {
        if (!playing)
        {
            if (counter > 0.5)
            {
                counter = counter - Time.deltaTime;
                textCountdown.text = Mathf.Floor(counter+1).ToString();
            }
            else
            {
                playing = true;
                panelStart.SetActive(false);
                music.Play();
            }
        }
    }
}
