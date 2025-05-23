using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackPrefab;  
    public Transform attackSpawnPoint;  
    public float attackSpeed = 20f;  
    public float attackCooldown = 0.5f;

    private bool canAttack = true;
    private PlayerParry playerParry;
    public Animator animatorAttack;

    void Start()
    {
        playerParry = GetComponent<PlayerParry>();
    }

    public void OnAttack()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if (canAttack && !playerParry.IsChargingParry)
        {
            Attack();
        }
    }

    void Attack()
    {
        animatorAttack.SetTrigger("Attack");
        canAttack = false;
        GameObject newAttack = Instantiate(attackPrefab, attackSpawnPoint.position, attackSpawnPoint.rotation);
        Rigidbody rb = newAttack.GetComponent<Rigidbody>();
        rb.linearVelocity = attackSpawnPoint.forward * attackSpeed;
        
        Invoke(nameof(ResetAttack), attackCooldown);
    }

    void ResetAttack()
    {
        canAttack = true;
    }
}
