using UnityEngine;

public class Aspirar : MonoBehaviour
{

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Trash"))
        {
            Destroy(other.gameObject);
        }
    }
}
