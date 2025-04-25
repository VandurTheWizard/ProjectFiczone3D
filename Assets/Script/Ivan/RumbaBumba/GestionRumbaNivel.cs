using UnityEngine;

public class GestionRumbaNivel : MonoBehaviour
{
    private GeneradorBasura basuraManager;
    public int nivel = 2;
    public int maximoNivel = 3;
    public float tiempo = 15f;
    private TemporizadorNivel temporizador;
    private FinishMiniGame finishMiniGame;
    public bool isInfinite = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        NuevoNivel();
        
    }

    public void NuevoNivel(){
        basuraManager = FindFirstObjectByType<GeneradorBasura>();
        basuraManager.SetNumeroBasuraDisponible(nivel);
        
        temporizador = FindFirstObjectByType<TemporizadorNivel>();
        temporizador.TiempoRestante(tiempo);

        finishMiniGame = FindFirstObjectByType<FinishMiniGame>();

        if(nivel > maximoNivel)
            nivel = maximoNivel;
            
        basuraManager.IniciarNivel();
    }

    public void FinTiempo(){
        finishMiniGame.Finish(false);
    }

    public void GanarNivel(){
        nivel++;
        finishMiniGame.Finish(true);
    }

}
