using UnityEngine;
using TMPro;

public class TemporizadorNivel : MonoBehaviour
{
    public float tiempoRestante = 60f;
    public TextMeshProUGUI textMesh;
    private GestionRumbaNivel gestionRumba;
    private bool timeIsOver = false;

    void Start()
    {
        gestionRumba = FindFirstObjectByType<GestionRumbaNivel>();
        if(textMesh == null){
            textMesh = GetComponent<TextMeshProUGUI>();
        }   
    }

    void Update()
    {
        tiempoRestante -= Time.deltaTime;
        if(timeIsOver) return;

        if(tiempoRestante <= 0f){
            timeIsOver = true;
            tiempoRestante = 0f;
            gestionRumba.FinTiempo();
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
