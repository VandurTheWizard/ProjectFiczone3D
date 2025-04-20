using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    [System.Serializable]
    public class Tutorial
    {
        public string nombreEscena;
        public GameObject objetoTutorial;
        public bool volverAVer = true;
    }

    public Tutorial[] tutoriales;
    private Tutorial tutorialActual;

    private bool primeraCarga = true;

    void Awake()
    {
        if (FindObjectsByType<TutorialManager>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Escena cargada: " + scene.name);
        MostrarTutorialParaEscena(scene.name);
    }

    void MostrarTutorial()
    {
        string nombreEscenaActual = SceneManager.GetActiveScene().name;
        MostrarTutorialParaEscena(nombreEscenaActual);
    }

    void MostrarTutorialParaEscena(string nombreEscena)
    {
        foreach (Tutorial t in tutoriales)
        {
            if (t.nombreEscena == nombreEscena)
            {
                tutorialActual = t;
                if (tutorialActual.volverAVer && tutorialActual.objetoTutorial != null)
                {
                    Instantiate(tutorialActual.objetoTutorial, Vector3.zero, Quaternion.identity);
                }
                return;
            }
        }
        if(primeraCarga){
            primeraCarga = false;
            return;
        }
        Destroy(gameObject);
    }

    public void VolverAVerTutorial(bool volverAVerInput)
    {
        if (tutorialActual != null)
        {
            tutorialActual.volverAVer = volverAVerInput;
        }
    }

    public void SalirTutorial()
    {
        if (tutorialActual != null && tutorialActual.objetoTutorial != null)
        {
            tutorialActual.objetoTutorial.SetActive(false);
        }
    }
}