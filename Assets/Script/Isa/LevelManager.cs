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
    [HideInInspector] public bool end = false;
    [HideInInspector] public int currentBurguer=0;
    [HideInInspector] public int currentLevelt=0;

    private float counter;

    public bool isRandom = false;

    private void Awake()
    {
        if (Instance != null && Instance != this) { }
        else Instance = this;
    }

    [HideInInspector] public int finalScore;
    [HideInInspector] public int fails;
    public void EndGame(bool isWin)
    {
        end = true;
        music.Stop();

        Debug.Log("Bara haz lo tuyo. Score: " + finalScore + "Fallos: " + fails);
        Debug.Log("No soy bara soy pokemon");
        if (isWin)
        {
            GestionSheep.winAndGoingNextScene(isRandom);
        }
        else
        {
            GestionSheep.loseAndGoingNextScene(isRandom);
        }

    }

    private void Start()
    {
        panelStart.SetActive(true);
        textCountdown.text = "3";
        counter = 3;
    }

    private void Update()
    {
        if (Time.deltaTime == 0)
        {
            return;
        }
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
