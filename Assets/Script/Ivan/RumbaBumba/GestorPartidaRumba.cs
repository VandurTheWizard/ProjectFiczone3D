using UnityEngine;

public class GestorPartidaRumba : MonoBehaviour
{
    public int numeroBasura;

    public void ObtenerNumeroBasura(int numeroBasura)
    {
        Debug.Log("Numero de basura: " + numeroBasura);
        this.numeroBasura = numeroBasura;
        if (numeroBasura <= 0)
        {
            ActivarPlataforma();
        }
    }

    public void BasuraRecogida()
    {
        numeroBasura--;
        if (numeroBasura <= 0)
        {
            ActivarPlataforma();
        }
    }

    private void ActivarPlataforma()
    {
        Plataforma plataforma = FindFirstObjectByType<Plataforma>();
        if (plataforma != null)
        {
            plataforma.esFuncional = true;
        }
    }


}
