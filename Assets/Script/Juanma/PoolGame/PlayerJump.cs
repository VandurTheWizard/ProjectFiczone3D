using UnityEngine;
using UnityEngine.InputSystem;

public class DivePlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float fallSpeed = 10f;
    public bool isFalling = false;
    private Vector2 moveInput;
    private Rigidbody rb;
    public FallTracker fallTracker;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        fallTracker.isTracking = false;
    }

    public void OnMove(InputValue value)
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        moveInput = value.Get<Vector2>();
    }

    public void OnJump()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if (!isFalling)
        {
            isFalling = true;
            rb.useGravity = true;
            fallTracker.isTracking=true;
        }
    }

    void FixedUpdate()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if (isFalling)
        {
            Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y) * moveSpeed;
            rb.AddForce(move, ForceMode.Acceleration);
            rb.linearDamping = 0f;
            rb.angularDamping = 0f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            Debug.Log("Fallaste!");
            isFalling = false;
            rb.useGravity = false;
            rb.linearVelocity = Vector3.zero;
            fallTracker.StopTracking();
            // Falta que el jugador explote y se reinicie el nivel
        } else if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("¡Bien hecho! Caíste limpio");
            isFalling = false;
            rb.useGravity = false;
            rb.linearVelocity = Vector3.zero;
            fallTracker.StopTracking();
            // Falta que el jugador gane y pasemos de nivel
        }
        else
        {
            //Tocó la pared, capaz en algun nivel esto elimine al jugador
        }

        
    }
}
