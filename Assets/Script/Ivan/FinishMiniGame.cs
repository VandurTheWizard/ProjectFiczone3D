using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMiniGame : MonoBehaviour
{
    public bool isInfinite = false;
    public AnimacionesFinPartida animacionesFinPartida;

    public void Finish(bool isWin){
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
        animacionesFinPartida.AnimacionPerdedora();
        Invoke("ExitToMainMenu", 2f);
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
