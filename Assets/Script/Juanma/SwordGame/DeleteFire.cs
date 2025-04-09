using UnityEngine;

public class DeleteFire : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Player"))
        {
            HealthManager.instance.DamagePlayer(1);
            Destroy(this.gameObject);
        }
    }
}
