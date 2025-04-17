using UnityEngine;

public class FireDugeonFireFloor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<FireDugeonController>().touchFireFloor = true;
        }
    }
}
