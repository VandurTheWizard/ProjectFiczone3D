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

    private void Start()
    {
        cameraMain = Camera.main;
        gameGestions = GameObject.FindAnyObjectByType<GameGestions>();
    }

    private void OnLook(InputValue input)
    {

        Vector2 mousePosition = input.Get<Vector2>();

        Vector2 position = Mouse.current.position.ReadValue();
        float mouseX = mousePosition.x * sensitivity * (Time.deltaTime / Time.timeScale);
        int borderMargin = 100;

        Debug.Log(mousePosition.x + "");

        if (position.x < borderMargin && mouseX < 0)
        {
            yRotation += mouseX;
            yRotation = Mathf.Clamp(yRotation, minMovementY, maxMovementY);
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
            return;
        }

        if (position.x > Screen.width - borderMargin && mouseX > 0)
        {
            yRotation += mouseX;
            yRotation = Mathf.Clamp(yRotation, minMovementY, maxMovementY);
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
            return;
        }

    }

    private void OnAttack()
    {
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
