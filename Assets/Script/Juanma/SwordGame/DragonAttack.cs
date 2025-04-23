using UnityEngine;
using System.Collections;

public class DragonAttack : MonoBehaviour
{
    public GameObject firePrefab;
    public Transform spawnLeft;
    public Transform spawnRight;
    public Transform spawnCenter;

    public float fireSpeed;
    public float attackCooldown = 2f;
    public float bigAttackCooldown = 3f;

    private int attackCounter = 0;

    void Start()
    {
        StartCoroutine(AttackLoop());
    }

    IEnumerator AttackLoop()
    {
        while (true)
        {

            if (attackCounter < 10)
            {
                int attackType = Random.Range(0, 3); // 0 = Normal, 1 = Mediano

                if (attackType < 2)
                {
                    attackCooldown = 0.7f;
                    AttackNormal();
                }
                else
                {
                    attackCooldown = 1.5f;
                    AttackMedium();
                }

                attackCounter++;
                yield return new WaitForSeconds(attackCooldown);
            }
            else
            {
                AttackBig();
                attackCounter = 0;
                yield return new WaitForSeconds(bigAttackCooldown);
            }
        }
    }

    void AttackNormal()
    {
        int randomPos = Random.Range(0, 3); // 0 = Izq, 1 = Centro, 2 = Der
        Transform spawnPoint = (randomPos == 0) ? spawnLeft : (randomPos == 1) ? spawnCenter : spawnRight;
        SpawnFire(spawnPoint, 25f);
    }

    void AttackMedium()
    {
        bool attackLeft = Random.value < 0.5f;

        if (attackLeft)
        {
            SpawnFire(spawnLeft, 20f);
            SpawnFire(spawnCenter, 20f);
        }
        else
        {
            SpawnFire(spawnRight, 20f);
            SpawnFire(spawnCenter, 20f);
        }
    }

    void AttackBig()
    {
        SpawnFire(spawnLeft, 10f);
        SpawnFire(spawnCenter, 10f);
        SpawnFire(spawnRight, 10f);
    }

    void SpawnFire(Transform spawnPoint, float fireSpeed)
    {
        GameObject fire = Instantiate(firePrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rb = fire.GetComponent<Rigidbody>();
        rb.linearVelocity = spawnPoint.forward * fireSpeed;
    }
}
