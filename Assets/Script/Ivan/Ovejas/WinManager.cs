using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinManager : MonoBehaviour
{
    [Header("Referencias")]    
    [SerializeField] private Image pulgarImage;
    [SerializeField] private Image fondoImage;

    [Header("Animaciones")]
    public Vector3 firstShowHandPos;
    public Vector3 showHandPos;
    public Vector3 hideHandPos;



    void Start()
    {
        OcultarContenido();
    }

    void Update()
    {
        
    } 

    private void OcultarContenido(){
        pulgarImage.gameObject.SetActive(false);
        fondoImage.gameObject.SetActive(false);
    }


}