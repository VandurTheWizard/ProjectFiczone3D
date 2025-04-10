using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectRotator : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private Vector2 moveInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            moveInput = context.ReadValue<Vector2>();
        }
    }

    void Update()
    {
        float rotationX = -moveInput.y * rotationSpeed * Time.deltaTime;
        float rotationY = moveInput.x * rotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.right, rotationX, Space.World);
        transform.Rotate(Vector3.up, rotationY, Space.World);
        //transform.Rotate(rotationX, rotationY, 0);
    }
}