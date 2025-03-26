using UnityEngine;

public class CreateGameController : MonoBehaviour
{
    public int[] microgamesScene;
    public int baseScene;
    public int loseScene;

    private static ControllerGame game; 
    private void Awake()
    {
        if(game == null)
        {
            game = gameObject.AddComponent<ControllerGame>();
            game.microgameScenes = microgamesScene;
            game.baseScene = baseScene;
            game.loseScene = loseScene;
        }
        Destroy(this);
    }
}
