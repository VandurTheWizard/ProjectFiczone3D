using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public int sensitivity = 200;
    public float minMovementY = -30;
    public float maxMovementY = 30;

    private float yRotation = 0f;
    private int laserDistance = 999;

    private Camera cameraMain;
    private GameGestions gameGestions;
    Vector2 mousePosition;

    private void Start()
    {
        cameraMain = Camera.main;
        gameGestions = GameObject.FindAnyObjectByType<GameGestions>();
    }

    private void OnMove(InputValue input)
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        mousePosition = input.Get<Vector2>();

    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        float mouseX = mousePosition.x * sensitivity * (Time.deltaTime / Time.timeScale);

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, minMovementY, maxMovementY);
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }

    private void OnAttack()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = cameraMain.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, laserDistance))
        {
            GameObject targer = hit.collider.gameObject;
            if (targer.CompareTag("Enemy"))
            {

                if (targer.GetComponent<EnemyNinjaScript>().isFind())
                {
                    gameGestions.findNinja();
                }
                
            }
            

        }

    }

}
