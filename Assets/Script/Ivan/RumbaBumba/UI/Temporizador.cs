using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Temporadizador : MonoBehaviour
{
    public float tiempoRestante = 60f;
    public TextMeshProUGUI textMesh;
    private GestionRumba gestionRumba;
    private bool timeIsOver = false;

    void Start()
    {
        gestionRumba = FindFirstObjectByType<GestionRumba>();
        if(textMesh == null){
            textMesh = GetComponent<TextMeshProUGUI>();
        }   
    }

    void Update()
    {
        if(timeIsOver) return;
        tiempoRestante -= Time.deltaTime;
        if(tiempoRestante <= 0f){
            timeIsOver = true;
            tiempoRestante = 0f;
            gestionRumba.FinTiempo();
        }   
        textMesh.text = (int)tiempoRestante + "";
    }

    public void TiempoRestante(float tiempoRestante){
        this.tiempoRestante = tiempoRestante;
    }



}
