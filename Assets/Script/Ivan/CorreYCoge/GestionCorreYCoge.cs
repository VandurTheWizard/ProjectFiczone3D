using UnityEngine;

public class GestionCorreYCoge : MonoBehaviour
{
    private GeneracionMeteoritos generacionMeteoritos;
    public int nivel = 0;
    public int maximoNivel = 3;
    public float tiempo = 10f;
    public float tiempoXNivel = 5f;
    private TemporizadorSupervivencia temporizador;
    private FinishMiniGame finishMiniGame;
    private TemporizadorPuntuacion temporizadorPuntuacion;

    private bool isLose = false;

    void Start()
    {

        NuevoNivel();
        
    }

    public void NuevoNivel(){
        generacionMeteoritos = FindFirstObjectByType<GeneracionMeteoritos>();
        generacionMeteoritos.spawnInterval = generacionMeteoritos.spawnInterval - nivel * 0.1f;
        
        temporizador = FindFirstObjectByType<TemporizadorSupervivencia>();
        if(temporizador != null){
            temporizador.TiempoRestante(tiempo + nivel * 5f);
        }else{
            temporizadorPuntuacion = FindFirstObjectByType<TemporizadorPuntuacion>();
        }

        finishMiniGame = FindFirstObjectByType<FinishMiniGame>();

        if(nivel > maximoNivel)
            nivel = maximoNivel;
        else
            nivel++;
    }

    public void PerderNivel(){
        if (isLose) return;
        
        isLose = true;
        if(temporizadorPuntuacion != null)
            temporizadorPuntuacion.PararTemporizador();
            
        finishMiniGame.Finish(false);
        Invoke("DestruirGestionCorreYCoge", 2.5f);
    }

    public void GanarNivel(){
        finishMiniGame.Finish(true);
    }

    public void DestruirGestionCorreYCoge(){
        Destroy(gameObject);
    }
}