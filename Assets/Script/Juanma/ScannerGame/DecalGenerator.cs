using UnityEngine;

public class DecalGenerator : MonoBehaviour
{
    public GameObject decalPrefab;
    public Transform targetObject;
    public float offsetFromSurface = 0.1f;

    void Start()
    {
        if (targetObject == null)
        {
            GameObject found = GameObject.FindGameObjectWithTag("Fire");
            if (found != null)
            {
                targetObject = found.transform;
            }
            else
            {
                Debug.LogWarning("No se encontró un objeto con el tag 'Fire'");
            }
        }
        SpawnDecals();
    }

public void SpawnDecals()
    {
        Renderer targetRenderer = targetObject.GetComponentInChildren<Renderer>();
        if (targetRenderer == null)
        {
            Debug.LogWarning("El objeto no tiene Renderer para calcular el área.");
            return;
        }

        Bounds bounds = targetRenderer.bounds;
        Vector3 center = bounds.center;
        float maxDistance = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z) * 2f;

        Vector3 randomDir = Random.onUnitSphere.normalized;
        Vector3 origin = center + randomDir * maxDistance;

        Ray ray = new Ray(origin, -randomDir);
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance * 2f))
        {
            if (!hit.collider.transform.IsChildOf(targetObject)) return;
            
            float distanceFromSurface = 0.2f;

            Vector3 spawnPos = hit.point + hit.normal * distanceFromSurface;

            Quaternion rotation = Quaternion.LookRotation(-hit.normal); 


            GameObject decal = Instantiate(decalPrefab, spawnPos, rotation);
            decal.transform.SetParent(targetObject);
        }
        else
        {
            Debug.LogWarning("Raycast falló al intentar generar decal.");
        }
    }

    public void UpdateTarget(Transform newTarget)
    {
        targetObject = newTarget;
    }






}


