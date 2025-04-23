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

    private bool isLose = false;

    void Start()
    {
        if (FindObjectsByType<GestionCorreYCoge>(FindObjectsSortMode.None).Length > 1)
        {
            // El objeto que no es el actual debe llamar a NuevoNivel
            GestionCorreYCoge[] objetosGestionCorreYCoge = FindObjectsByType<GestionCorreYCoge>(FindObjectsSortMode.None);
            for (int i = 0; i < objetosGestionCorreYCoge.Length; i++)
            {
                if (objetosGestionCorreYCoge[i] != this)
                {
                    objetosGestionCorreYCoge[i].NuevoNivel();
                }
            }

            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        NuevoNivel();
        
    }
    public void NuevoNivel(){
        generacionMeteoritos = FindFirstObjectByType<GeneracionMeteoritos>();
        generacionMeteoritos.spawnInterval = generacionMeteoritos.spawnInterval - nivel * 0.1f;
        
        temporizador = FindFirstObjectByType<TemporizadorSupervivencia>();
        temporizador.TiempoRestante(tiempo + nivel * 5f);

        finishMiniGame = FindFirstObjectByType<FinishMiniGame>();

        if(nivel > maximoNivel)
            nivel = maximoNivel;
            
    }

    public void PerderNivel(){
        if (isLose) return;
        
        isLose = true;
        finishMiniGame.Finish(false);
        Invoke("DestruirGestionCorreYCoge", 2.5f);
    }

    public void GanarNivel(){
        nivel++;
        finishMiniGame.Finish(true);
    }

    public void DestruirGestionCorreYCoge(){
        Destroy(gameObject);
    }
}