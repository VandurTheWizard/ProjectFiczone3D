using UnityEngine;

public class GeneradorPlataformaRumba : MonoBehaviour
{
    [SerializeField] private GameObject [] plataformas;
    
    void Start()
    {
        if(!ComprobarArrayPlataformas())
            RellenarArrayPlataformas();

        DesactivarPlataformas();
        SeleccionarPlataforma();
    }

    private bool ComprobarArrayPlataformas()
    {
        return plataformas.Length > 0;
    }

    private void RellenarArrayPlataformas()
    {
        plataformas = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            plataformas[i] = transform.GetChild(i).gameObject;
        }
    }

    private void DesactivarPlataformas()
    {
        for (int i = 0; i < plataformas.Length; i++)
        {
            plataformas[i].SetActive(false);
        }
    }

    private void SeleccionarPlataforma()
    {
        int randomIndex = Random.Range(0, plataformas.Length); 
        
        plataformas[randomIndex].SetActive(true); 
    }
}
