using UnityEngine;

public class LaserRotator : MonoBehaviour
{
    public float minSpeed = 30f;
    public float maxSpeed = 70f;

    private float rotationSpeed;

    void Start()
    {
        rotationSpeed = Random.Range(minSpeed, maxSpeed);
        if (Random.value < 0.5f)
        {
            rotationSpeed *= -1f;
        }
    }

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime,0, 0);
    }
}
