using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectRotator : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private Vector2 moveInput;
    public TextMeshProUGUI textMeshPro;
    public GameObject imag1;
    public GameObject imag2;

    private void Start()
    {
        StartCoroutine(disableText());
    }
    public void OnMove(InputValue value)
    {
        if(Time.timeScale == 0)
        {
            moveInput = Vector2.zero;
            return;
        }
            moveInput = value.Get<Vector2>();
           
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        float rotationX = -moveInput.y * rotationSpeed * Time.deltaTime;
        float rotationY = moveInput.x * rotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.right, rotationX, Space.World);
        transform.Rotate(Vector3.up, rotationY, Space.World);
        //transform.Rotate(rotationX, rotationY, 0);
    }

    private IEnumerator disableText()
    {
        while (true)
        {

            if (Time.timeScale == 0)
            {
                textMeshPro.gameObject.SetActive(false);
                imag1.SetActive(false);
                imag2.SetActive(false);
                yield return new WaitForSeconds(0.001f);
            }
            else
            {
                imag1.SetActive(true);
                imag2.SetActive(true);
                textMeshPro.gameObject.SetActive(true);

            }

            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

}