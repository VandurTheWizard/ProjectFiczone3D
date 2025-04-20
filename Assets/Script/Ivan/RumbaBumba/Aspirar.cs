using UnityEngine;

public class Aspirar : MonoBehaviour
{
    public GestorPartidaRumba gestorPartidaRumba;
    private bool inPlataforma = false;

    void Start()
    {
        gestorPartidaRumba = GetComponent<GestorPartidaRumba>();
    } 

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Trash"))
        {
            gestorPartidaRumba.BasuraRecogida();
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trash") && !inPlataforma)
        {
            Plataforma plataforma = collision.gameObject.GetComponent<Plataforma>();
            if(plataforma != null){
                if (plataforma.GetEsFuncional())
                {
                    Temporadizador temporadizador = FindFirstObjectByType<Temporadizador>();
                    if (temporadizador != null)
                    {
                        temporadizador.PararTemporizador();
                    }

                    inPlataforma = true;
                    FinishMiniGame finishMiniGame = FindFirstObjectByType<FinishMiniGame>();
                    if (finishMiniGame != null)
                    {
                        GestionRumba gestionRumba = FindFirstObjectByType<GestionRumba>();
                        if (gestionRumba != null)
                        {
                            gestionRumba.GanarNivel();
                        }
                        
                    }
                }
            }
        }
    }
}
