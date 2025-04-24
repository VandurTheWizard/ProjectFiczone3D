using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;

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

    public TextMeshProUGUI textPlayer;
    public TextMeshProUGUI textDrako;
    public GameObject img1;
    public GameObject img2;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        enemyHealth = fullEnemyHealth;
        if (dragonSlider != null)
            dragonSlider.maxValue = fullEnemyHealth;
        UpdateUI();
        StartCoroutine(disableText());
    }

    private IEnumerator disableText()
    {
        while (true)
        {

            if (Time.timeScale == 0)
            {
                    textPlayer.gameObject.SetActive(false);
                    textDrako.gameObject.SetActive(false);
                    img1.SetActive(false);
                    img2.SetActive(false);
                    heart1.SetActive(false);
                    heart2.SetActive(false);
                    heart3.SetActive(false);
                    yield return new WaitForSeconds(0.1f);
            }
            else
            {
                textPlayer.gameObject.SetActive(true);
                textDrako.gameObject.SetActive(true);
                img1.SetActive(true);
                img2.SetActive(true);
                switch (playerHealth)
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

            }

            yield return new WaitForSecondsRealtime(0.1f);
        }
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
        }
    }

    void CheckEnemyDefeat()
    {
        if (enemyHealth <= 0)
        {
            fill.SetActive(false);
            Debug.Log("¡Victoria! Has derrotado al dragón.");
            loadNextScene();
        }
    }

    public void loadNextScene()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        RandomGameController.loadScene(nextScene);
    }
}
