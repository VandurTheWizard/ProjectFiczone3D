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


    public void OnParry()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if (!canParry) return;

            isCharging = true;
            chargeTime = 0f;

            if (chargeTime >= minChargeTime)
            {
                PerformParry();
            }

    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
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
