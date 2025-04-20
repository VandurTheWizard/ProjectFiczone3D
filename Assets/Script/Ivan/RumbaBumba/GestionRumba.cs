using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionRumba : MonoBehaviour
{
    private GeneradorBasura basuraManager;
    public int nivel = 0;
    public int maximoNivel = 3;
    public float tiempo = 10f;
    public float tiempoXNivel = 5f;
    private Temporadizador temporizador;
    private FinishMiniGame finishMiniGame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Si en la escena ya existe un objeto de tipo GestionRumba, se destruye el nuevo
        if (FindObjectsByType<GestionRumba>(FindObjectsSortMode.None).Length > 1)
        {
            // El objeto que no es el actual debe llamar a NuevoNivel
            GestionRumba[] objetosGestionRumba = FindObjectsByType<GestionRumba>(FindObjectsSortMode.None);
            for (int i = 0; i < objetosGestionRumba.Length; i++)
            {
                if (objetosGestionRumba[i] != this)
                {
                    objetosGestionRumba[i].NuevoNivel();
                }
            }

            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        NuevoNivel();
        
    }

    public void NuevoNivel(){
        basuraManager = FindFirstObjectByType<GeneradorBasura>();
        basuraManager.SetNumeroBasuraDisponible(nivel);
        
        temporizador = FindFirstObjectByType<Temporadizador>();
        temporizador.TiempoRestante(tiempo + nivel * 5f);

        finishMiniGame = FindFirstObjectByType<FinishMiniGame>();

        if(nivel > maximoNivel)
            nivel = maximoNivel;
            
        basuraManager.IniciarNivel();
    }

    public void FinTiempo(){
        finishMiniGame.Finish(false);
        Invoke("DestruirGestionRumba", 2.5f);
    }

    public void GanarNivel(){
        nivel++;
        finishMiniGame.Finish(true);
    }

    private void DestruirGestionRumba(){
        Destroy(gameObject);
    }

}
