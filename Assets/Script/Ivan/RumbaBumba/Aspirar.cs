using UnityEngine;

public class Aspirar : MonoBehaviour
{
    public GameObject spawnPoint;

    private GameObject parentObject;

    void Start()
    {
        parentObject = transform.parent.gameObject;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Trash"))
        {
            parentObject.transform.localScale += new Vector3(10, 10, 10);
            transform.localScale += new Vector3(0.1f, 0.1f, 0);
            other.transform.position = spawnPoint.transform.position;
        }
    }
}
