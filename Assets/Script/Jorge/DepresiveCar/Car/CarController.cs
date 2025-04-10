using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarControlller : MonoBehaviour
{
    public int sensivility = 15;
    public int velocityUp = 5;

    private Vector2 VectorValue;

    private float firstValueX = 0;
    private float valueX = 0;

    private float time = 0;
    private float maxTime = 10;

    private ControllerGame controller;
    private bool isLose = false;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        firstValueX = transform.position.x;
        controller = GameObject.FindAnyObjectByType<ControllerGame>();
    }
    private void OnMove(InputValue value)
    {
        VectorValue = value.Get<Vector2>();
    }

    private void Update()
    {
        valueX += sensivility * VectorValue.x * Time.deltaTime;
        if (valueX > 0)
        {
            valueX = 0;
        }
        if (valueX < -1)
        {
            valueX = -1;
        }

        transform.position = new Vector3(firstValueX + valueX, transform.position.y, transform.position.z + velocityUp * Time.deltaTime);

        time += Time.deltaTime / Time.timeScale;
        if(time > maxTime && !isLose)
        {
            Cursor.lockState = CursorLockMode.None;
            controller.Victory();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CarEnemies"))
        {
            isLose = true;
            StartCoroutine(wait());
        }
        
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        Cursor.lockState = CursorLockMode.None;
        controller.Lose(); 
    }
}