using System.Collections.Generic;
using UnityEngine;

public class Basura : MonoBehaviour
{
    [SerializeField] private List<GameObject> listaBasura = new List<GameObject>();
    [SerializeField] private int numeroBasuraDisponible = 1;

    public void IniciarNivel(){
        if (!ComprobarArrayBasura())
            RellenarArrayBasura();

        DesactivarBasura();
        SeleccionarBasura();
    }

    public void SetNumeroBasuraDisponible(int numeroBasura)
    {
        numeroBasuraDisponible = numeroBasura;
    }

    private bool ComprobarArrayBasura()
    {
        return listaBasura.Count > 0;
    }

    private void RellenarArrayBasura()
    {
        listaBasura.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            listaBasura.Add(transform.GetChild(i).gameObject);
        }
    }

    private void DesactivarBasura()
    {
        foreach (var basura in listaBasura)
        {
            if (basura != null)
                basura.SetActive(false);
        }
    }

    private void SeleccionarBasura()
    {
        if (numeroBasuraDisponible > listaBasura.Count)
            numeroBasuraDisponible = listaBasura.Count;
            
        for (int i = 0; i < numeroBasuraDisponible; i++)
        {
            int randomIndex = Random.Range(0, listaBasura.Count);

            if (listaBasura[randomIndex] != null)
            {
                listaBasura[randomIndex].SetActive(true);
                listaBasura.RemoveAt(randomIndex);
            }
        }
    }



}
