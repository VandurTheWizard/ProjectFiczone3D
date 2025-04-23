using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int playerHealth;
    private int enemyHealth;
    public int fullEnemyHealth = 30;

    public TMP_Text playerHealthText;
    public TMP_Text enemyHealthText;

    public Slider dragonSlider;
    public GameObject fill;
    public GameObject heart1, heart2, heart3;

    public string nextScene = "";

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 1;
        enemyHealth = fullEnemyHealth;
        if (dragonSlider != null)
            dragonSlider.maxValue = fullEnemyHealth;
        UpdateUI();
    }

    public void DamagePlayer(int damage)
    {
        playerHealth -= damage;
        UpdateUI();
        CheckGameOver();
    }

    public void DamageEnemy(int damage)
    {
        enemyHealth -= damage;
        UpdateUI();
        CheckEnemyDefeat();
    }

    void UpdateUI()
    {
        //playerHealthText.text = "Player HP " + playerHealth + "/3";
        //enemyHealthText.text = "Dragon HP " + enemyHealth + "/50";
        switch(playerHealth)
        {
            case 0:
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
            case 1:
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
            case 2:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
                break;
            case 3:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;

        }
        dragonSlider.value = enemyHealth;
    }

    void CheckGameOver()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("Game Over! El jugador ha sido derrotado.");
            loadNextScene();
            Time.timeScale = 0;
        }
    }

    void CheckEnemyDefeat()
    {
        if (enemyHealth <= 0)
        {
            fill.SetActive(false);
            Debug.Log("¡Victoria! Has derrotado al dragón.");
            loadNextScene();
            Time.timeScale = 0;
        }
    }

    public void loadNextScene()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        RandomGameController.loadScene(nextScene);
    }
}
