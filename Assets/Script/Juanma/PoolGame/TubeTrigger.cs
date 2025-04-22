using UnityEngine;

public class TubeTrigger : MonoBehaviour
{
    private bool hasSpawned = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasSpawned || !other.CompareTag("Player"))
            return;

        hasSpawned = true;

        InfiniteMode controller = FindFirstObjectByType<InfiniteMode>();
        if (controller != null && controller.isInfinite)
        {
            controller.SpawnNextTube(transform.root.position);
        }
        else
        {
            Debug.LogError("InfiniteMode no encontrado o no está activado.");
        }
    }
}
