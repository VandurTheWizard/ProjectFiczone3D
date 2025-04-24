using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionRumba : MonoBehaviour
{
    private GeneradorBasura basuraManager;
    public int nivel = 0;
    public int maximoNivel = 3;
    public float tiempo = 10f;
    public float tiempoAcomulado = 0;
    private Temporadizador temporizador;
    private FinishMiniGame finishMiniGame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (FindObjectsByType<GestionRumba>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        NuevoNivel();
        
    }

     void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        DontDestroyOnLoad(gameObject);

        NuevoNivel();

        Debug.Log("Escena cargada: " + scene.name);
        if (scene.name != "RumbaBumbaInfinito")
        {
            Debug.Log("Escena cagada");
            Destroy(gameObject);
            return;
        }
    }

    public void NuevoNivel(){
        basuraManager = FindFirstObjectByType<GeneradorBasura>();
        basuraManager.SetNumeroBasuraDisponible(nivel);
        
        temporizador = FindFirstObjectByType<Temporadizador>();
        temporizador.TiempoRestante(tiempo + tiempoAcomulado);

        finishMiniGame = FindFirstObjectByType<FinishMiniGame>();

        if(nivel > maximoNivel)
            nivel = maximoNivel;
            
        basuraManager.IniciarNivel();
    }

    public void FinTiempo(){
        LeaderBoardGestions.activateLeaderBoardNotTime("Rumba", nivel);
        finishMiniGame.Finish(false);
        
        Invoke("DestruirGestionRumba", 0);
    }

    public void GanarNivel(){
        nivel++;
        tiempoAcomulado = temporizador.TiempoSobrante();
        finishMiniGame.Finish(true);
    }

    private void DestruirGestionRumba(){
        Destroy(gameObject);
    }

}
