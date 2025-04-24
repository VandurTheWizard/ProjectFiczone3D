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
        if (Time.timeScale == 0)
        {
            return;
        }
        tiempoRestante -= Time.deltaTime;
        if(timeIsOver) return;
        
        if(tiempoRestante <= 0f ){
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

    public float TiempoSobrante(){
        return tiempoRestante;
    }

    public void PararTemporizador(){
        timeIsOver = true;
    }


}
