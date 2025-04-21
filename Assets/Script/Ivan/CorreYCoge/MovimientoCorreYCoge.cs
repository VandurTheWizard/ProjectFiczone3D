using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoCorreYCoge : MonoBehaviour
{
    public float zPlano = 0f; // Define el plano Z donde se moverá el objeto
    public float alturaFija = 0f; // Define la altura fija (eje Y) del objeto

    public void OnMoveMouse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 mousePosition = context.ReadValue<Vector2>();
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - zPlano)));
            worldPosition.y = alturaFija; // Fija la altura (eje Y)
            transform.position = worldPosition;
        }
    }
}