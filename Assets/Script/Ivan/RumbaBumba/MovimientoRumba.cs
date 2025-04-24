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
        if (Time.timeScale == 0)
        {
            return;
        }
        if (!estaEnMovimiento)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * velocidadRotacion);
        }else
        {
            rb.linearVelocity = -(transform.up * velocidad);
        }
    }

    public void OnJump()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

       
        estaEnMovimiento = !estaEnMovimiento;
        spriteRenderer.gameObject.SetActive(!estaEnMovimiento);


    }
}
