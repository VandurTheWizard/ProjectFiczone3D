using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoRumba : MonoBehaviour
{
    [Header("Ajustes de movimiento")]
    public float velocidad = 5f;
    public float velocidadRotacion = 200f;

    private bool estaEnMovimiento = false;
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!estaEnMovimiento)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * velocidadRotacion);
        }else
        {
            rb.linearVelocity = -(transform.up * velocidad);
        }
    }

    public void isMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            spriteRenderer.gameObject.SetActive(false);
            estaEnMovimiento = !estaEnMovimiento;
        }else if (context.canceled)
        {
            spriteRenderer.gameObject.SetActive(true);
            estaEnMovimiento = false;
        }
    }
}
