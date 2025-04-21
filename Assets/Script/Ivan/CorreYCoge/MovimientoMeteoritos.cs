using UnityEngine;

public class MeteoritoMovil : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f; // Velocidad en el eje Z (negativo para ir hacia atrás)
    public bool rotarAleatoriamente = true; // Si queremos que gire como un meteorito real
    public Vector3 rotacionMin = new Vector3(0, 0, -30); // Rotación mínima (eje X, Y, Z)
    public Vector3 rotacionMax = new Vector3(30, 30, 30); // Rotación máxima (eje X, Y, Z)

    [Header("Tiempo de vida")]
    public float tiempoDeVida = 3f; // Segundos antes de autodestruirse

    private Vector3 rotacionAleatoria;

    void Start()
    {
        // Configura una rotación aleatoria inicial (si está activado)
        if (rotarAleatoriamente)
        {
            rotacionAleatoria = new Vector3(
                Random.Range(rotacionMin.x, rotacionMax.x),
                Random.Range(rotacionMin.y, rotacionMax.y),
                Random.Range(rotacionMin.z, rotacionMax.z)
            );
        }

        // Destruye el objeto después del tiempo de vida
        Destroy(gameObject, tiempoDeVida);
    }

    void Update()
    {
        // Movimiento en Z (hacia adelante o atrás según la velocidad)
        transform.Translate(0, 0, velocidad * Time.deltaTime);

        // Rotación progresiva (si está activada)
        if (rotarAleatoriamente)
        {
            transform.Rotate(rotacionAleatoria * Time.deltaTime);
        }
    }
}