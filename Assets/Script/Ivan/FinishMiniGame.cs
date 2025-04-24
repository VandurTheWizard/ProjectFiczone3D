using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMiniGame : MonoBehaviour
{
    public bool isInfinite = false;
    public AnimacionesFinPartida animacionesFinPartida;
    private bool isGameFinished = false;

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
        animacionesFinPartida.AnimacionGanadora();
        Invoke("NextLevel", 2f);
    }

    private void AnimationLose(){
        GestionSheep.loseAndGoingNextScene(true);
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
            Debug.Log("Cargar escena aleatoria");
        }
    }
}
