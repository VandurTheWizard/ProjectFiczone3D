using UnityEngine;

public class DartBoard : MonoBehaviour
{
    public bool isGood = false;

    private DartGameGestion game;

    void Start()
    {
        game = FindAnyObjectByType<DartGameGestion>();
    }

    private void OnDestroy()
    {
        if (isGood) {
            game.life--;
        }
        else
        {
            game.point += 10;
        }
    }

    public void NormalDelete()
    {
        isGood = !isGood;
    }

}
