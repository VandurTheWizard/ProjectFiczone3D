using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int playerHealth = 10;
    public int enemyHealth = 20;

    public TMP_Text playerHealthText;
    public TMP_Text enemyHealthText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
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
        playerHealthText.text = "Player HP " + playerHealth + "/10";
        enemyHealthText.text = "Dragon HP " + enemyHealth + "/20";
    }

    void CheckGameOver()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("Game Over! El jugador ha sido derrotado.");
        }
    }

    void CheckEnemyDefeat()
    {
        if (enemyHealth <= 0)
        {
            Debug.Log("¡Victoria! Has derrotado al dragón.");
        }
    }
}
