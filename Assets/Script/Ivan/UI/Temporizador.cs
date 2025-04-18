using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Temporadizador : MonoBehaviour
{
    public float tiempoRestante = 60f;
    public TextMeshProUGUI textMesh;
    private GestionRumba gestionRumba;

    void Start()
    {
        gestionRumba = FindFirstObjectByType<GestionRumba>();
        if(textMesh == null){
            textMesh = GetComponent<TextMeshProUGUI>();
        }   
    }

    void Update()
    {
        tiempoRestante -= Time.deltaTime;
        if(tiempoRestante <= 0f){
            tiempoRestante = 0f;
            gestionRumba.FinTiempo();
        }   
        textMesh.text = (int)tiempoRestante + "";
    }

    public void TiempoRestante(float tiempoRestante){
        this.tiempoRestante = tiempoRestante;
    }



}
