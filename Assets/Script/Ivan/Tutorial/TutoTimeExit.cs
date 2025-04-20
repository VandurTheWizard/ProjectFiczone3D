using UnityEngine;

public class TutoTimeExit : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f;
    }

    public void RestablecerTiempoYEliminar()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}
