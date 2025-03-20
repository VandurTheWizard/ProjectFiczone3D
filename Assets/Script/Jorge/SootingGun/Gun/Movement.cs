using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public int sensitivity = 200;
    public float minMovementY = -30;
    public float maxMovementY = 30;

    private float yRotation = 0f;

    public GameObject pointOfGun;
    private int balloons = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnLook(InputValue input)
    {
        Vector2 vector = input.Get<Vector2>();

        float mouseX = vector.x * sensitivity * Time.deltaTime;
        float mouseY = vector.y * sensitivity * Time.deltaTime;

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, minMovementY, maxMovementY);

        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }

    private void OnAttack()
    {
        Debug.DrawLine(pointOfGun.transform.position, -pointOfGun.transform.right * 99, Color.green, 99);
        if(Physics.Raycast(pointOfGun.transform.position, -pointOfGun.transform.right * 99, out RaycastHit hit, 99f)){
            if (hit.collider.gameObject.CompareTag("Bubble"))
            {
                balloons++;
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
