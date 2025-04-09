using UnityEngine;
using UnityEngine.InputSystem;

public class DivePlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float fallSpeed = 10f;
    public bool isFalling = false;
    private Vector2 moveInput;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && !isFalling)
        {
            isFalling = true;
            rb.useGravity = true;
        }
    }

    void FixedUpdate()
    {
        if (isFalling)
        {
            Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y) * moveSpeed;
            rb.AddForce(move, ForceMode.Acceleration);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Fallaste, caíste sobre alguien");
        }
        else
        {
            Debug.Log("¡Bien hecho! Caíste limpio");
        }

        isFalling = false;
        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
    }
}
