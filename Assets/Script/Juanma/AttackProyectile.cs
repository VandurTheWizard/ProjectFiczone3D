using UnityEngine;

public class AttackProjectile : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            HealthManager.instance.DamageEnemy(1);
            Destroy(gameObject);
        }

        if (other.CompareTag("Fire"))
        {
            Destroy(gameObject);
        }
    }
}
