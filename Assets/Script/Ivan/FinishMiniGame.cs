using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMiniGame : MonoBehaviour
{
    public bool isInfinite = false;
    public AnimacionesFinPartida animacionesFinPartida;
    private bool isGameFinished = false;
    public bool isRandom = true;

    public void Finish(bool isWin){
        if (isGameFinished) return;
        isGameFinished = true;
        Debug.Log("Fin del juego: " + (isWin ? "Ganaste" : "Perdiste"));
        if (isWin)
        {
            AnimationWin();
        }
        else
        {
            AnimationLose();
        }
    }

    private void AnimationWin(){
        //animacionesFinPartida.AnimacionGanadora();
        Invoke("NextLevel", 0);
    }

    private void AnimationLose(){
        GestionSheep.loseAndGoingNextScene(isRandom);
    }

    private void ExitToMainMenu(){
        Debug.Log("Exit to Main Menu");
    }

    private void NextLevel(){
        if (isInfinite)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            GestionSheep.winAndGoingNextScene(isRandom);// Si la siguiente es escena es Random o normal
        }
    }
}
