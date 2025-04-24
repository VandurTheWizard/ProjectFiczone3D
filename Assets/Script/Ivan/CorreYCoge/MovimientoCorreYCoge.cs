using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class MovimientoCorreYCoge : MonoBehaviour
{
    public float zPlano = 0f;
    public float alturaFija = 0f;
    public bool isLose = false;
    private Vector2 mousePosition;
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    } 

    public void OnMovimientoRaton(InputValue value)
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if (!isLose)
        {
            mousePosition = value.Get<Vector2>();
        }
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        if (!isLose)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - zPlano)));
            worldPosition.y = alturaFija; // Fija la altura (Y)
            transform.position = worldPosition;
        }
    }
}