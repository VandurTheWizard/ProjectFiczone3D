using UnityEngine;

public class MovementOfBallons : MonoBehaviour
{
    private float velocity = 5;
    private bool isUp = true;

    private int maxMovementY = 2;
    private int minMovementY = -5;

    void Update()
    {
        if (isUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + velocity * Time.deltaTime, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - velocity * Time.deltaTime, transform.position.z);
        }
      
        if(transform.position.y > maxMovementY && isUp)
        {
            isUp = false;
        }
        if(transform.position.y < minMovementY && !isUp)
        {
            isUp = true;
        }
        
    }
}
