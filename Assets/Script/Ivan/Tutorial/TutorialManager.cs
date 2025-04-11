using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject [] paginas;
    [SerializeField] private float tamanoEspacio = 50f;
    [SerializeField] private GameObject botonPrefab;
    [SerializeField] private GameObject espacioPaginas;
    private RectTransform rectTransform;
    void Start()
    {
        int numPaginas = paginas.Length;

        rectTransform = espacioPaginas.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(numPaginas * 50, rectTransform.sizeDelta.y);

        for (int i = 0; i < numPaginas; i++)
        {
            CrearBoton(i);
        }
    }

    public void CambiarPagina(int pagina)
    {
         for (int i = 0; i < paginas.Length; i++)
        {
            if (i == pagina)
            {
                paginas[i].GetComponent<BotonPagina>().SetActivoBool(true);
                paginas[i].SetActive(true);
            }
            else
            {
                paginas[i].GetComponent<BotonPagina>().SetActivoBool(false);
                paginas[i].SetActive(false);
            }
        }
    }

    private void CrearBoton(int pagina){
        GameObject boton = Instantiate(botonPrefab, espacioPaginas.transform);
        boton.GetComponent<RectTransform>().anchoredPosition = new Vector2(pagina * tamanoEspacio + 25 - (rectTransform.sizeDelta.x / 2), 0);
        boton.GetComponent<BotonPagina>().pagina = pagina;
        boton.GetComponent<BotonPagina>().tutorialManager = gameObject;
        if(pagina == 0)
        {
            boton.GetComponent<BotonPagina>().SetActivoBool(true);
        }
        else
        {
            boton.GetComponent<BotonPagina>().SetActivoBool(false);
        }
    }
}
