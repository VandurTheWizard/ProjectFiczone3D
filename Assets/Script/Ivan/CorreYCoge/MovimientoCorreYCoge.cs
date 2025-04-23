using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoCorreYCoge : MonoBehaviour
{
    public float zPlano = 0f;
    public float alturaFija = 0f;
    public bool isLose = false;

    void Start()
    {
        Cursor.visible = false;

    } 

    public void OnMoveMouse(InputAction.CallbackContext context)
    {
        if (context.performed && !isLose)
        {
            Vector2 mousePosition = context.ReadValue<Vector2>();
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - zPlano)));
            worldPosition.y = alturaFija; // Fija la altura (Y)
            transform.position = worldPosition;
        }
    }
}