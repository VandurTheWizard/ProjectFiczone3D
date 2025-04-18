using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionRumba : MonoBehaviour
{
    private Basura basuraManager;
    public int nivel = 0;
    public float tiempo = 10f;
    private Temporadizador temporizador;

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
        nivel++;
        basuraManager = FindFirstObjectByType<Basura>();
        basuraManager.SetNumeroBasuraDisponible(nivel);
        temporizador = FindFirstObjectByType<Temporadizador>();
        temporizador.TiempoRestante(tiempo);
        basuraManager.IniciarNivel();
    }

    public void FinTiempo(){
        Debug.Log("Fin del tiempo");
        Debug.Log("Muestra final de nivel");
        Debug.Log("Destruye GestionRumba");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GanarNivel(){
        nivel++;
        Debug.Log("Ganaste el nivel " + nivel);
    }


}
