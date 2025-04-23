
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
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
    private bool isAddPoint = true;

    public bool isInfinity = false;
    public string nextScene = "";

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        firstValueX = transform.position.x;
        StartCoroutine(isPointEnable());
    }
    private void OnMove(InputValue value)
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        VectorValue = value.Get<Vector2>();
    }

    private IEnumerator isPointEnable()
    {
        while (true) {
            if (Time.deltaTime == 0)
            {
                textMeshProUGUI.gameObject.SetActive(false);
            }
            else
            {
                textMeshProUGUI.gameObject.SetActive(true);
            }
            yield return new WaitForSecondsRealtime(0.1f);

        }
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
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
        if (isAddPoint)
        {
            point += Time.deltaTime * 10 * (int)(Time.timeScale / 0.05) ;
        }
        if (time > maxTime)
        {
            time = 0;
            Time.timeScale += 0.05f;
        }
        int pointa = (int)point;
        textMeshProUGUI.text = "Your point: " + pointa;
        if (pointa > 10000 && !isInfinity)
        {
            loadNextScene();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CarEnemies"))
        {
            if (isInfinity)
            {
                loseInfinity();
            }
            else
            {
                loadNextScene();
            }

        }

    }

    private void loseInfinity()
    {
        isAddPoint = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        LeaderBoardGestions.activateLeaderBoardNotTime("dd", (int)point);

    }

    private void loadNextScene()
    {
        isAddPoint = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        RandomGameController.loadScene(nextScene);
    }
}