using UnityEngine;
using UnityEngine.InputSystem;

public class DecalClicker : MonoBehaviour
{
    private Camera mainCamera;
    private DecalGenerator decalGenerator;
    private Timer timer;
    
    void Start()
    {
        mainCamera = Camera.main;
        decalGenerator = FindAnyObjectByType<DecalGenerator>();
        timer = FindAnyObjectByType<Timer>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("¡Decal Clicked!");
                    ScoreManager.Instance.AddPoints(10); 
                    decalGenerator.SpawnDecals();
                    timer.AddTime(0.5f);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
