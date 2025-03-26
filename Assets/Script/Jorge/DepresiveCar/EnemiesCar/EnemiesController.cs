using UnityEngine;

public class EnemiesController : MonoBehaviour
{

    private int velocity = 15;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - velocity * Time.deltaTime);
    }
}
