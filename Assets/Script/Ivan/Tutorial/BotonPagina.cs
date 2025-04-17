using UnityEngine;
using UnityEngine.UI;

public class BotonPagina : MonoBehaviour
{
    [SerializeField] private Sprite activo;
    [SerializeField] private Sprite inactivo;
    public int pagina;
    public GameObject tutorialManager;
    private bool activoBool = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (activoBool)
        {
            GetComponent<Image>().sprite = activo;
        }
        else
        {
            GetComponent<Image>().sprite = inactivo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetActivoBool()
    {
        return activoBool;
    }

    public void SetActivoBool(bool value)
    {
        activoBool = value;
        if (activoBool)
        {
            GetComponent<Image>().sprite = activo;
        }
        else
        {
            GetComponent<Image>().sprite = inactivo;
        }
    }

    //Si se clica el boton, se cambia la pagina
    private void OnMouseDown()
    {
        Debug.Log("Cambiando pagina a: " + pagina);
        tutorialManager.GetComponent<TutorialManager>().CambiarPagina(pagina);
    }

    


}
