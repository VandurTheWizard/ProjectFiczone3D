using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToRandom : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SceneManager.LoadScene("MenuSeleccion");   
    }
}
