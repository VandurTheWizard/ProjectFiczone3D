using UnityEngine;

public class ParryEffect : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            Destroy(other.gameObject);
        }
    }
}
