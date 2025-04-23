using UnityEngine;
using TMPro;

public class TemporizadorPuntuacion : MonoBehaviour
{
    public float tiempoPuntuacion = 10f;
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
        if(timeIsOver) return;
        tiempoPuntuacion += Time.deltaTime;

        
        textMesh.text = (int)tiempoPuntuacion + "";

        
    }

    public void TiempoRestante(float tiempoRestante){
        this.tiempoPuntuacion = tiempoRestante;
    }

    public void PararTemporizador(){
        timeIsOver = true;
    }
}
