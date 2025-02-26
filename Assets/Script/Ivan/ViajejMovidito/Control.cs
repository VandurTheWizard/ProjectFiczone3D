using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Control : MonoBehaviour
{
    [Header("Atributos")]
    public float fuerzaSalto = 10f;
    public float porcentajeEscalaAgachado = 0.5f;

    private Rigidbody rb;
    private bool enSuelo = true;
    private float escalaInicial;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        escalaInicial = transform.localScale.y;
    }

    public void OnBend(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.z, escalaInicial * porcentajeEscalaAgachado);
        }
        else if (context.canceled)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.z, escalaInicial);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enSuelo = false;
        }
    }


}
