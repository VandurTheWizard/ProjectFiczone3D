using UnityEngine;

public class ShootingGunController : MonoBehaviour
{

    public int balloonHasBeenDestroy;

    public int ballonsDestroy;

    private float time = 0;
    private int MaxTime = 10;

    private ControllerGame controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GameObject.FindAnyObjectByType<ControllerGame>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime / Time.timeScale;

        if (ballonsDestroy == balloonHasBeenDestroy)
        {
            Cursor.lockState = CursorLockMode.None;
            controller.Victory();
        }

        if (time >= MaxTime)
        {
            Cursor.lockState = CursorLockMode.None;
            controller.Lose();
        }
    }

}
