using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinManager : MonoBehaviour
{
    [Header("Referencias")]    
    [SerializeField] private Image pulgarImage;
    [SerializeField] private Image ovejaImage;
    [SerializeField] private Image fondoImage;

    [Header("Animaciones")]
    public Vector3 firstShowSheepPos;
    public Vector3 showSheepPos;
    public Vector3 hideHandPos;
    public float velocidad = 0.5f;
    public float tiempoEspera = 1f;

    private bool anim1 = false;
    private bool anim2 = false;



    void Start()
    {
        OcultarContenido();
    }

    void Update()
    {
        if(!anim1){
            pulgarImage.transform.localPosition = Vector3.Lerp(pulgarImage.transform.localPosition, hideHandPos, Time.deltaTime * velocidad);
            if(Vector3.Distance(pulgarImage.transform.localPosition, hideHandPos) < 0.1f){
                anim1 = true;
            }
        }else{
            if(!anim2){
                pulgarImage.transform.localPosition = Vector3.Lerp(pulgarImage.transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime * velocidad);
                if(Vector3.Distance(pulgarImage.transform.localPosition, new Vector3(0, 0, 0)) < 0.1f){
                    anim2 = true;
                }
            }
        }
    } 

    private void OcultarContenido(){
        pulgarImage.gameObject.SetActive(false);
        fondoImage.gameObject.SetActive(false);
    }


}