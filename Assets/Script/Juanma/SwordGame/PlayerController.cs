using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float threshold = 0.1f;
    public GameObject posIzq, posDer, posCenter;

    void Start()
    {
        transform.position = posCenter.transform.position;
    }

    public void OnDodgeLeft(InputAction.CallbackContext context)
    {
        if (context.performed) // Solo ejecuta cuando la acción se completa
        {
            Vector3 currentPosition = transform.position;

            if (Vector3.Distance(currentPosition, posCenter.transform.position) < threshold)
            {
                transform.position = posIzq.transform.position;
            }
            else if (Vector3.Distance(currentPosition, posDer.transform.position) < threshold)
            {
                transform.position = posCenter.transform.position;
            }
        }
    }

    public void OnDodgeRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 currentPosition = transform.position;

            if (Vector3.Distance(currentPosition, posCenter.transform.position) < threshold)
            {
                transform.position = posDer.transform.position;
            }
            else if (Vector3.Distance(currentPosition, posIzq.transform.position) < threshold)
            {
                transform.position = posCenter.transform.position;
            }
        }
    }
}
