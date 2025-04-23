using UnityEngine;

public class UIManagerScanner : MonoBehaviour
{
    public static UIManagerScanner Instance;

    public Canvas mainCanvas;
    public GameObject pointsPopupPrefab;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}
