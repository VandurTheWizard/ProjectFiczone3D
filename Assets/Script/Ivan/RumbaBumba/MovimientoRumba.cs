using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoRumba : MonoBehaviour
{
    [Header("Ajustes de movimiento")]
    public float velocidad = 5f;
    public float velocidadRotacion = 200f;

    private bool estaEnMovimiento = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!estaEnMovimiento)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * velocidadRotacion);
        }else
        {
            // Se mueve en coordenada local hacia abajo
            rb.linearVelocity = -(transform.up * velocidad);

        }
    }

    public void isMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            estaEnMovimiento = !estaEnMovimiento;
        }else if (context.canceled)
        {
            estaEnMovimiento = false;
        }
    }
}
