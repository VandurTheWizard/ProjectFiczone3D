using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
    public float tiempoRestante = 60f;
    public TextMeshProUGUI textMesh;

    void Start()
    {
        if(textMesh == null){
            textMesh = GetComponent<TextMeshProUGUI>();
        }   
    }

    void Update()
    {
        tiempoRestante -= Time.deltaTime;
        if(tiempoRestante <= 0f){
            tiempoRestante = 0f;
            Debug.Log("You lose");
        }   
        textMesh.text = (int)tiempoRestante + "";
    }

}
