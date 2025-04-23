using UnityEngine;

public class InfiniteMode : MonoBehaviour
{
    public bool isInfinite = false;
    public string nextScene = "";
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

    public void loadNextScene()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        RandomGameController.loadScene(nextScene);
    }

    public void loseInfinity(float point)
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        LeaderBoardGestions.activateLeaderBoardNotTime("dd", (int)point);

    }
}
