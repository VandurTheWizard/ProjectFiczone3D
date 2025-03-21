using UnityEditor;
using UnityEngine;

public class CreateGameController : MonoBehaviour
{
    public SceneAsset[] microgamesScene;
    public SceneAsset baseScene;
    public SceneAsset loseScene;

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
