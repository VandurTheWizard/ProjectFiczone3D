using UnityEngine;
using TMPro;
using System.Collections;

public class TemporizadorPuntuacion : MonoBehaviour
{
    public float tiempoPuntuacion = 10f;
    public TextMeshProUGUI textMesh;
    public GameObject imagen;
    public GameObject text2;
    private GestionCorreYCoge gestionCorreYCoge;
    private bool timeIsOver = false;

    void Start()
    {
        gestionCorreYCoge = FindFirstObjectByType<GestionCorreYCoge>();
        if(textMesh == null){
            textMesh = GetComponent<TextMeshProUGUI>();
        }
        StartCoroutine(canvasDisable());
    }

    private IEnumerator canvasDisable()
    {
        if (Time.timeScale == 0)
        {
            textMesh.gameObject.SetActive(false);
            imagen.SetActive(false);
            text2.SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
        else
        {
            textMesh.gameObject.SetActive(true);
            imagen.SetActive(true);
            text2.SetActive(true);
        }
        yield return new WaitForSecondsRealtime(0.1f);
    }
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if (timeIsOver){
            LeaderBoardGestions.activateLeaderBoardNotTime("Aliencito", (int)tiempoPuntuacion);
            return;
        } 
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
