using UnityEngine;
using TMPro;

public class TemporizadorSupervivencia : MonoBehaviour
{
    public float tiempoRestante = 10f;
    public TextMeshProUGUI textMesh;
    private GestionCorreYCoge gestionCorreYCoge;
    private bool timeIsOver = false;

    void Start()
    {
        gestionCorreYCoge = FindFirstObjectByType<GestionCorreYCoge>();
        if(textMesh == null){
            textMesh = GetComponent<TextMeshProUGUI>();
        }   
    }

    void Update()
    {
        tiempoRestante -= Time.deltaTime;

        if(tiempoRestante <= 0f){
            tiempoRestante = 0f;
            gestionCorreYCoge.GanarNivel();
        }else{
            textMesh.text = (int)tiempoRestante + "";
        }

        
    }

    public void TiempoRestante(float tiempoRestante){
        this.tiempoRestante = tiempoRestante;
    }

    public void PararTemporizador(){
        timeIsOver = true;
    }
}