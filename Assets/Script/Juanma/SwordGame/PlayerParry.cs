using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerParry : MonoBehaviour
{
    public GameObject parryEffectPrefab;  
    public Transform parrySpawnPoint;  

    public float maxChargeTime = 1f; 
    public float minChargeTime = 0.3f;
    public float parryCooldown = 2f;

    private float chargeTime = 0f;
    private bool isCharging = false;
    private bool canParry = true;

    public bool IsChargingParry => isCharging;
    public Animator animatorParry;
    public Animator SwordParry;


    public void OnParry(InputAction.CallbackContext context)
    {
        if (!canParry) return;

        if (context.started)
        {
            isCharging = true;
            chargeTime = 0f;
        }
        else if (context.canceled)
        {
            if (chargeTime >= minChargeTime)
            {
                PerformParry();
            }
            isCharging = false;
        }
    }

    void Update()
    {
        if (isCharging)
        {
            chargeTime += Time.deltaTime;

            if (chargeTime >= maxChargeTime)
            {
                PerformParry();
                isCharging = false;
            }
        }
    }

    void PerformParry()
    {
        animatorParry.SetTrigger("Parry");
        SwordParry.SetTrigger("Parry");
        canParry = false;
        GameObject parryEffect = Instantiate(parryEffectPrefab, parrySpawnPoint.position, Quaternion.identity);
        Destroy(parryEffect, 0.5f);

        Invoke(nameof(ResetParry), parryCooldown);
    }

    void ResetParry()
    {
        canParry = true;
    }
}
