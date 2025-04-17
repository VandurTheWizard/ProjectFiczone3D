using System.Collections;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CarControllerInfinity : MonoBehaviour
{
    public int sensivility = 15;
    public int velocityUp = 5;

    private Vector2 VectorValue;

    private float firstValueX = 0;
    private float valueX = 0;

    private float time = 0;
    private float maxTime = 3;

    public TextMeshProUGUI textMeshProUGUI;
    
    private float point = 0;
    public string nextScene;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        firstValueX = transform.position.x;
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
        point += Time.deltaTime * 10;
        if (time > maxTime)
        {
            time = 0;
            Time.timeScale += 0.05f;
        }
        int pointa = (int)point;
        textMeshProUGUI.text = "Your point: " + pointa;


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CarEnemies"))
        {
            StartCoroutine(wait());
        }
        
    }

    private IEnumerator wait()
    {
        
        Time.timeScale = 0;
        yield return new WaitForSeconds(1);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(nextScene);

    }
}