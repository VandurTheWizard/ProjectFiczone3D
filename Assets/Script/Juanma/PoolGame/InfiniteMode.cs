using UnityEngine;

public class InfiniteMode : MonoBehaviour
{
    public bool isInfinite = false;
    public GameObject cilindro;
    public GameObject Win;

    public void SpawnNextTube(Vector3 currentTubePosition)
    {
        if (!isInfinite) return;
        Win.SetActive(false);
        Vector3 newPosition = currentTubePosition + new Vector3(0f, -315f, 0f);
        Quaternion uprightRotation = Quaternion.Euler(90f, 0f, 0f);
        Instantiate(cilindro, newPosition, uprightRotation);
    }
}
