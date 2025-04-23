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
        if (Time.timeScale == 0)
        {
            return;
        }
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("¡Decal Clicked!");
                    Vector3 screenPos = Mouse.current.position.ReadValue();
                    GameObject popup = Instantiate(UIManagerScanner.Instance.pointsPopupPrefab, UIManagerScanner.Instance.mainCanvas.transform);
                    popup.transform.position = screenPos;
                    ScoreManager.Instance.AddPoints(10); 
                    decalGenerator.SpawnDecals();
                    timer.AddTime(0.5f);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
