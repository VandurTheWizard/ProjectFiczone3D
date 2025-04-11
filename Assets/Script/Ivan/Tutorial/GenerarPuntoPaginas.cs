using UnityEngine;

public class GenerarPuntoPaginas : MonoBehaviour
{
   [SerializeField] private GameObject [] puntosPaginas;
   [SerializeField] private float tamanoEspacio = 50f;
   [SerializeField] private GameObject botonPrefab;

    void Start()
    {
        int numPaginas = puntosPaginas.Length;

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(numPaginas * 50, rectTransform.sizeDelta.y);

        
    }

    
}
