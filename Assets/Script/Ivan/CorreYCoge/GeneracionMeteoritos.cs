using UnityEngine;

public class GeneracionMeteoritos : MonoBehaviour
{
    public GameObject prefabToSpawn; // Prefab a generar
    public float xMin = -5f; // Límite mínimo en X
    public float xMax = 5f; // Límite máximo en X
    public float spawnInterval = 2f; // Tiempo entre spawns (segundos)
    public bool spawnAtStart = true; // Generar al inicio

    void Start()
    {
        if (spawnAtStart)
            SpawnObject();

        InvokeRepeating("SpawnObject", spawnInterval, spawnInterval);
    }

    void SpawnObject()
    {
        // Calcula X aleatorio entre xMin y xMax
        float randomX = Random.Range(xMin, xMax);

        // Mantiene Y y Z iguales a las del objeto padre
        Vector3 spawnPosition = new Vector3(
            randomX, 
            transform.position.y, 
            transform.position.z
        );

        // Instancia el objeto
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }

    // Opcional: Dibuja un Gizmo para ver el rango en el Editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 minPos = new Vector3(xMin, transform.position.y, transform.position.z);
        Vector3 maxPos = new Vector3(xMax, transform.position.y, transform.position.z);
        Gizmos.DrawLine(minPos, maxPos);
        Gizmos.DrawSphere(minPos, 0.2f);
        Gizmos.DrawSphere(maxPos, 0.2f);
    }
}