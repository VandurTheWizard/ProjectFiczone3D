using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public bool esFuncional = false;
    public Light rojo;
    public Light verde;

    void Start()
    {
        if (esFuncional)
        {
            verde.enabled = true;
            rojo.enabled = false;
        }
        else
        {
            verde.enabled = false;
            rojo.enabled = true;
        }
    } 

    public bool GetEsFuncional()
    {
        return esFuncional;
    }

    public void SetEsFuncional(bool esFuncional)
    {
        this.esFuncional = esFuncional;
        if (esFuncional)
        {
            verde.enabled = true;
            rojo.enabled = false;
        }
        else
        {
            verde.enabled = false;
            rojo.enabled = true;
        }
    }
}
