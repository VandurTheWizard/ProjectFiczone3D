using UnityEngine;

public class EnemiesController : MonoBehaviour
{

    private int velocity = 15;

    private float time = 0;

    private float maxTime = 2;
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - velocity * Time.deltaTime);
        time += Time.deltaTime;

        if(time > maxTime)
        {
            Destroy(gameObject);
        }
    }
}
