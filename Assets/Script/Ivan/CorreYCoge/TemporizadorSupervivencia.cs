using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Collections;

public class TemporizadorSupervivencia : MonoBehaviour
{
    public float tiempoRestante = 10f;
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
        while (true)
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
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        tiempoRestante -= Time.deltaTime;

        if(tiempoRestante <= 0f && !timeIsOver){
            timeIsOver = true;
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