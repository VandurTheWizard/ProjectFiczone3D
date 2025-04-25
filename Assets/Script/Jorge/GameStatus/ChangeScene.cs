using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   public void changeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void startRandom()
    {
        RandomGameController.startModeRandom();
    }
}
